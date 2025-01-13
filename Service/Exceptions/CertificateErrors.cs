using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class CertificateErrors
    {
        public static Error ExistedCertificate => new("Upload Certificate", "The certificate has been uploaded. Please edit the certificate to change it.");
        public static Error UploadFail => new("Upload Certificate", "The certificate upload fail");
        public static Error FailProcess => new("Upload Certificate", "Failed to process certificate");
        public static Error OverLimitSize => new("Upload Certificate", "File size can not exceeds the 500MB limit.");


    }
}
