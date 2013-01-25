using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTPNet
{
    /**
        * TOTP - One time password generator 
        * 
        * The TOTP class allow for the generation 
        * and verification of one-time password using 
        * the TOTP specified algorithm.
        *
        * This class is meant to be compatible with 
        * Google Authenticator
        *
        * This class was originally ported from the rotp
        * ruby library available at https://github.com/mdp/rotp
        */
    public class TOTP : OTP
    {

        /**
         * The interval in seconds for a one-time password timeframe
         * Defaults to 30
         * @var integer
         */
        public double interval;


        public TOTP(string secret)
            : base(secret, 6, HashAlgorithm.SHA1)
        {
            this.interval = 30;
        }

        public TOTP(string secret, double interval)
            : base(secret, 6, HashAlgorithm.SHA1)
        {
            this.interval = interval;
        }

        public TOTP(string secret, double interval, int digits)
            : base(secret, digits, HashAlgorithm.SHA1)
        {
            this.interval = interval;
        }

        public TOTP(string secret, double interval, int digits, HashAlgorithm algo)
            : base(secret, digits, algo)
        {
            this.interval = interval;
        }

        /**
         *  Get the password for a specific timestamp value 
         *
         *  @param integer $timestamp the timestamp which is timecoded and 
         *  used to seed the hmac hash function.
         *  @return integer the One Time Password
         */
        public int at(double timestamp)
        {
            return this.generateOTP(this.timecode(timestamp));
        }

        /**
         *  Get the password for the current timestamp value 
         *
         *  @return integer the current One Time Password
         */
        public int now()
        {
            return this.at(new Unixtime().toTimeStamp());
        }

        /**
         * Verify if a password is valid for a specific counter value
         *
         * @param integer $otp the one-time password 
         * @param integer $timestamp the timestamp for the a given time, defaults to current time.
         * @return  bool true if the counter is valid, false otherwise
         */
        public bool verify(int otp, double timestamp)
        {
            return (otp == this.at(timestamp));
        }

        public bool verify(int otp)
        {
            //calls verify(int, int)
            return this.verify(otp, new Unixtime().toTimeStamp());
        }

        /**
         * Returns the uri for a specific secret for totp method.
         * Can be encoded as a image for simple configuration in 
         * Google Authenticator.
         *
         * @param string $name the name of the account / profile
         * @return string the uri for the hmac secret
         */
        public string provisitioning_uri(string name)
        {
            return "otpauth://totp/" + name + "?secret=" + this.secret;
        }

        /**
         * Transform a timestamp in a counter based on specified internal
         *
         * @param integer $timestamp
         * @return integer the timecode
         */
        public Int64 timecode(double timestamp)
        {
            return (Int64)(((((timestamp * 1000)) / (this.interval * 1000))));
        }
    }
}
