using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicKeyCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success;

            //  First build a JWK sample to load..
            Chilkat.JsonObject json = new Chilkat.JsonObject();
            json.UpdateString("kty", "RSA");
            json.UpdateString("n", "qoQah4MFGYedrbWwFc3UkC1hpZlnB2_E922yRJfHqpq2tTHL_NvjYmssVdJBgSKi36cptKqUJ0Phui9Z_kk8zMPrPfV16h0ZfBzKsvIy6_d7cWnn163BMz46kAHtZXqXhNuj19IZRCDfNoqVVxxCIYvbsgInbzZM82CB86iYPAS7piijYn1S6hueVHGAzQorOetZevKIAvbH3kJXZ4KdY6Ffz5SFDJBxC3bycN4q2JM1qnyD53vcc0MitxyIUF7a06iJb5_xXBiA-3xnTI0FU5hw_k6x-sdB5Rglx13_2aNzdWBSBAnxs1XXtZUt9_2RAUxP1XORkrBGlPg9D7cBtQ");
            json.UpdateString("e", "AQAB");
            json.UpdateString("e", "AQAB");

            //  The JSON contains the following:
            //  {
            //    "kty": "RSA",
            //    "n": "33TqqLR3eeUmDtHS89qF3p4MP7Wfqt2Zjj3lZjLjjCGDvwr9cJNlNDiuKboODgUiT4ZdPWbOiMAfDcDzlOxA04DDnEFGAf-kDQiNSe2ZtqC7bnIc8-KSG_qOGQIVaay4Ucr6ovDkykO5Hxn7OU7sJp9TP9H0JH8zMQA6YzijYH9LsupTerrY3U6zyihVEDXXOv08vBHk50BMFJbE9iwFwnxCsU5-UZUZYw87Uu0n4LPFS9BT8tUIvAfnRXIEWCha3KbFWmdZQZlyrFw0buUEf0YN3_Q0auBkdbDR_ES2PbgKTJdkjc_rEeM0TxvOUf7HuUNOhrtAVEN1D5uuxE1WSw",
            //    "e": "AQAB",
            //  }

            //  Note: The JSON can contain other members, such as "use", "kid", or anything else.  These will be ignored.
            json.EmitCompact = false;

            //  Show the JWK string to be loaded:
            string jwkStr = json.Emit();

            Chilkat.PublicKey pubKey = new Chilkat.PublicKey();
            //  The LoadFromString method will automatically detect the format.
            success = pubKey.LoadFromString(jwkStr);
            if (success != true)
            {
                Console.WriteLine(pubKey.LastErrorText);
                return;
            }

            //  OK.. the JWK is loaded.  It can be used in whatever way desired...

            //  The key can be retrieved in any other format, such as XML or PEM..
            Console.WriteLine(pubKey.GetXml());

            //  XML output:
            //  <RSAPublicKey>
            //      <Modulus>33TqqLR3eeUmDtHS89qF3p4MP7Wfqt2Zjj3lZjLjjCGDvwr9cJNlNDiuKboODgUiT4ZdPWbOiMAfDcDzlOxA04DDnEFGAf+kDQiNSe2ZtqC7bnIc8+KSG/qOGQIVaay4Ucr6ovDkykO5Hxn7OU7sJp9TP9H0JH8zMQA6YzijYH9LsupTerrY3U6zyihVEDXXOv08vBHk50BMFJbE9iwFwnxCsU5+UZUZYw87Uu0n4LPFS9BT8tUIvAfnRXIEWCha3KbFWmdZQZlyrFw0buUEf0YN3/Q0auBkdbDR/ES2PbgKTJdkjc/rEeM0TxvOUf7HuUNOhrtAVEN1D5uuxE1WSw==</Modulus>
            //      <Exponent>AQAB</Exponent>
            //  </RSAPublicKey>

            //  Choose PCKS1 or PCKS8 PEM format..
            bool bPreferPkcs1 = false;
            Console.WriteLine(pubKey.GetPem(bPreferPkcs1));
        }
    }
}
