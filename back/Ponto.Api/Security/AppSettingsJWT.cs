using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Api.Security
{
    public class AppSettingsJWT
    {
        public string Secret { get; set; }
        public int ExpiracaoMinutos { get; set; }
        public string Emissor { get; set; }
        public string ValidoPara { get; set; }
    }
}
