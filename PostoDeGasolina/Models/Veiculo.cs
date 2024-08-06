﻿namespace PostoDeGasolina.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
    }

    public class Carro : Veiculo { }
    public class Moto : Veiculo { }
    public class Caminhao : Veiculo { }
}