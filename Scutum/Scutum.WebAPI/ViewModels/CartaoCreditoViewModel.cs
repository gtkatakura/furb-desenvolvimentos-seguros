using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scutum.WebAPI.ViewModels
{
    public class CartaoCreditoViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Senha { get; set; }
    }
}