using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RSAForms3
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        //byte[] encryptedData = null;
        ////byte[] decryptedData;
        //byte[] signature = null;
        //bool generated = false;
        //string signatureString = null;
        //RSAParameters RSAKeyInfo1;
        //RSAParameters rsaPrivateParams;
        //RSAParameters rsaPublicParams;
        byte[] toEncrypt;
        byte[] encrypted;
        byte[] signature;
        string original;
        string bytestring = "";
        ASCIIEncoding myAscii = new ASCIIEncoding();
        Sender mySender = new Sender();
        Receiver myReceiver = new Receiver();
        public Form1()
        {
            InitializeComponent();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            original = textBox1.Text;
            toEncrypt = myAscii.GetBytes(original);
            encrypted = mySender.EncryptData(myReceiver.PublicParameters, toEncrypt);
            signature = mySender.HashAndSign(encrypted);
            textBox2.Text = Encoding.ASCII.GetString(encrypted);
            //textBox3.Text = Encoding.ASCII.GetString(signature);
            
            foreach(byte item in signature)
            {
                try
                {
                    bytestring += signature[item].ToString();
                }
                catch (Exception) { }
            }
            textBox3.Text = bytestring;
            //string plaintext = textBox1.Text;
            //string hashedText = null;

            //encryptedData = null;
            ////decryptedData = null;
            //signature = null;
            //signatureString = null;
            //generated = false;
            //SHA1 sha = new SHA1Managed();
            //byte[] temp = sha.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
            ////StringBuilder sb = new StringBuilder();
            //hashedText = Encoding.ASCII.GetString(temp);

            //textBox2.Text = hashedText;

            //string encryptedDataString = null;
            //try
            //{
            //    UnicodeEncoding ByteConverter = new UnicodeEncoding();

            //    byte[] dataToEncrypt = ByteConverter.GetBytes(textBox2.Text);
            //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //    {
            //        rsaPrivateParams = RSA.ExportParameters(true);
            //        rsaPublicParams = RSA.ExportParameters(false);
            //        encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false));
            //        //decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
            //        encryptedDataString = Encoding.ASCII.GetString(encryptedData);
            //        signature = HashAndSign(encryptedData);
            //        signatureString = Encoding.ASCII.GetString(signature);
            //        textBox2.Text = encryptedDataString;
            //        textBox3.Text = signatureString;
            //        generated = true;
            //    }
            //}
            //catch (ArgumentNullException)
            //{
            //    MessageBox.Show("Encryption failed.");
            //}
        }

        //public byte[] HashAndSign(byte[] encrypted)
        //{
        //    //RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
        //    //SHA1Managed hash = new SHA1Managed();
        //    //byte[] hashedData;

        //    //rsaCSP.ImportParameters(rsaPrivateParams);

        //    //hashedData = hash.ComputeHash(encrypted);
        //    //return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"));
        //}

        //public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo)
        //{
        //    //RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

        //    //rsaCSP.ImportParameters(RSAKeyInfo);
        //    //return rsaCSP.Encrypt(DataToEncrypt, false);

        //    //try
        //    //{
        //    //    byte[] encryptedData;
        //    //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //    //    {
        //    //        RSA.ImportParameters(RSAKeyInfo);  
        //    //        encryptedData = RSA.Encrypt(DataToEncrypt, false);
        //    //    }
        //    //    return encryptedData;
        //    //}
        //    //catch (CryptographicException e)
        //    //{
        //    //    MessageBox.Show(e.Message);
        //    //    return null;
        //    //}

        //}

        private void button2_Click(object sender, EventArgs e)
        {

            if (bytestring != textBox3.Text)
            {
                form2.ReceiveText(mySender, myReceiver, encrypted, Encoding.ASCII.GetBytes(textBox3.Text), this);
            }
            else
            {
                form2.ReceiveText(mySender, myReceiver, encrypted, signature, this);
            }
            //if (generated == true)
            //{
            //    if (signatureString != textBox3.Text)
            //    {
            //        byte[] signatureBytes = Encoding.ASCII.GetBytes(textBox3.Text);
            //        form2.ReceiveText(encryptedData, signatureBytes, rsaPublicParams);
            //    }
            //    else
            //    {
            //        form2.ReceiveText(encryptedData, signature, rsaPublicParams);
            //    }
            //}
            //else { MessageBox.Show("There is nothing to send."); }

        }
    }
}