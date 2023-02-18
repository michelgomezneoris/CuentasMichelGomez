﻿using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Dtos.Cuentas
{
    public class CreateCuenta
    {
        public long TipoCuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public int Saldo { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }
    }
}
