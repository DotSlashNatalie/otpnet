using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTPNet
{
    /**
         * HOTP - One time password generator 
         * 
         * The HOTP class allow for the generation 
         * and verification of one-time password using 
         * the HOTP specified algorithm.
         *
         * This class is meant to be compatible with 
         * Google Authenticator
         *
         * This class was originally ported from the rotp
         * ruby library available at https://github.com/mdp/rotp
         */
    public class HOTP : OTP
    {

        public HOTP(string secret)
            : base(secret, 6, HashAlgorithm.SHA1)
        {

        }

        /**
         *  Get the password for a specific counter value
         *  @param integer $count the counter which is used to
         *  seed the hmac hash function.
         *  @return integer the One Time Password
         */
        public int at(int count)
        {
            return this.generateOTP(count);
        }

        /**
         * Verify if a password is valid for a specific counter value
         *
         * @param integer $otp the one-time password 
         * @param integer $counter the counter value
         * @return  bool true if the counter is valid, false otherwise
         */
        public bool verify(int otp, int counter)
        {
            return (otp == this.at(counter));
        }

        public string provisioning_uri(string name, int initial_count)
        {
            return "otpauth://hotp/" + name + "?secret=" + this.secret + " &counter=" + initial_count.ToString();
        }
    }
}
