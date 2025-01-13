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

    }
}
