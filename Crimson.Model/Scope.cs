namespace Crimson.Models
{
    public class Scope
    {
        public string Name { get; set; }

        /// <summary>
        /// Получает или задаёт коэффициент прицела.
        /// </summary>
        public double Multiplier { get; set; }
    }
}