using System;

namespace CarLibrary
{
    public class Car
    {
        public string Model { get; set; }
        public string  Color { get; set; }
        public string RegNo { get; set; }

        public override string ToString()
        {
            return "Model: " + Model + " Color " + Color + " Registratioin Number " + RegNo;
        }
    }
}
