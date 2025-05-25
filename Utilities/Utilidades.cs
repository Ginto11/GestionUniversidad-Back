using System.Security.Cryptography;
using System.Text;

namespace GestionUniversidad.Utilities
{
    public class Utilidades
    {
        private readonly IConfiguration config;

        public Utilidades(IConfiguration config)
        {
            this.config = config;
        }

        public string Encriptar(string texto)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(config["Encrypting:Key"]!);
            aes.IV = Encoding.UTF8.GetBytes(config["Encrypting:IV"]!);

            ICryptoTransform encriptor = aes.CreateEncryptor();

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, encriptor, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(texto);
            };

            return Convert.ToBase64String(memoryStream.ToArray());

        }

        public string Desencriptar (string textoEncriptado)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(config["Encrypting:Key"]!);
            aes.IV = Encoding.UTF8.GetBytes(config["Encrypting:IV"]!);

            ICryptoTransform decriptor = aes.CreateDecryptor();

            byte[] textoCifrado = Convert.FromBase64String(textoEncriptado);
            using MemoryStream memoryStream = new MemoryStream(textoCifrado);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decriptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();

        }
    }
}
