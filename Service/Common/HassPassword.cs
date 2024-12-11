﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public class HassPassword
    {
        public static Task<string> HassPass(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            return Task.Run(() =>
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            });
        }
    }
}
