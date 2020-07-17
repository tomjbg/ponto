using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Api.Configurations
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
