using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTPNet;

namespace otpnettest
{
    class Program
    {
        static void Main(string[] args)
        {
            TOTP t = new TOTP(args[0]);
            Console.WriteLine("Your OTP = " + t.now().ToString("D6"));
        }
    }
}
