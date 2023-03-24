using System.Security.Cryptography;
using System.Text;

class Hash {
    private byte[] key;

    public Hash() {
        
        key = new byte[32];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
            rng.GetBytes(key);
        }
    }

    public string ComputeHMAC(string message) {
        
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        using (HMACSHA256 hmac = new HMACSHA256(key)) {
            byte[] hmacBytes = hmac.ComputeHash(messageBytes);
            
            string hmacString = BitConverter.ToString(hmacBytes).Replace("-", "");
            return hmacString;
        }
    }

    public string GetOriginalKey() 
    {
        return BitConverter.ToString(key).Replace("-", "");
    }
}