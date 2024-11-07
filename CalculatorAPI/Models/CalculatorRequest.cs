﻿namespace CalculatorAPI.Models
{
    public class CalculatorRequest
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string Operation { get; set; } // pass arithmetic operators  e.g., "+", "-", "*", "/"
    }
}
