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
using System.IO;

namespace RSAForms3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Sender mySender;// = new Sender();
        Receiver myReceiver;// = new Receiver();

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        byte[] encrypted;
        byte[] signature;
        Form1 form1;
        //RSAParameters RSAKeyInfo;
        public void ReceiveText(Sender mySender, Receiver myReceiver, byte[] encrypted, byte[] signature, Form1 form1)
        {
            this.mySender = new Sender(); this.mySender = mySender;
            this.myReceiver = new Receiver(); this.myReceiver = myReceiver;
            this.encrypted = encrypted;
            this.signature = signature;
            this.form1 = form1;
            //this.encryptedData = null;
            //this.signature = null;
            //this.encryptedData = encryptedData;
            //this.signature = signature;
            //this.RSAKeyInfo = RSAKeyInfo;
            //RSACryptoServiceProvider RSAVerifier = new RSACryptoServiceProvider();
            //textBox1.Text = Encoding.ASCII.GetString(encryptedData);
            //textBox2.Text = Encoding.ASCII.GetString(signature);
            //bool verified = VerifyHash(RSAKeyInfo, encryptedData, signature);

        }

        //public bool VerifyHash(RSAParameters rsaParams, byte[] signedData, byte[] signature)
        //{
        //    //RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();
        //    //SHA1 sha = new SHA1Managed();
        //    //byte[] hashedData;
        //    //rsaCSP.ImportParameters(rsaParams);
        //    //bool dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signature);
        //    //hashedData = sha.ComputeHash(signedData);
        //    //return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature);
        //}
        private void VerifyButton_Click(object sender, EventArgs e)
        {
            if (myReceiver.VerifyHash(mySender.PublicParameters, encrypted, signature))
            {
                //Decrypt the data using the receiver's private key.
                myReceiver.DecryptData(encrypted);
                MessageBox.Show("SUCCESS");
            }
            else
            {
                MessageBox.Show("Invalid signature");
            }
            //bool verified = VerifyHash(RSAKeyInfo, encryptedData, signature);

            //if (verified == true)
            //{
            //    label4.ForeColor = Color.Green;
            //    label4.Text = "Message legit, bro.";
            //    label4.Font = new Font("Arial", 18, FontStyle.Bold);
            //}
            //else
            //{
            //    label4.ForeColor = Color.Red;
            //    label4.Text = "INTRUDER ALERT!";
            //    label4.Font = new Font("Arial", 24, FontStyle.Bold);
            //}
        }


    }
}
















/*


textBox1.Text = "" + sifruotasText;
textBox2.Text = "" + exp;
//rezultatasBox.Text = "" + tekstas;

if ((Math.Pow(Convert.ToDouble(sifruotasText), exp) % n) == tekstas % n) { rezultatasBox.Text = "" + (Math.Pow(Convert.ToDouble(sifruotasText), exp) % n) + ", " + tekstas % n; }
else { rezultatasBox.Text = "" + (Math.Pow(Convert.ToDouble(sifruotasText), exp) % n) + ", " + tekstas % n; }

*/
