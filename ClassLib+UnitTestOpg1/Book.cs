using System.Xml.Linq;

namespace ClassLib_UnitTestOpg1
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public double? Price { get; set; }



        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }


        public void ValidateTitle()
        {

            if (Title == null)
            {

                throw new ArgumentNullException((Title), "Title kan ikke være null");

            }
            if (Title.Length <= 3)

            {
                throw new ArgumentException("Titlen skal være minimum 3 tegn lang");

            }

        }

        public void ValidatePrice()
        {
            if (Price <=0)
            {
                throw new ArgumentOutOfRangeException("Price skal være højere end 0");
            }
            if (Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price skal være lavere end 1200");
            }
        }



        public void Validate()
        {
            ValidatePrice();
            ValidateTitle();
        }
    }
}