namespace Hackathon_Day {
    public class Card {
        public int id;
        public int value;
        public string name;
        public string suit;
        public string desc;
        public string modifier;

        public override string ToString(){
            string top = "*******************";
            string bottom = top;

            return $"{top}\n* Name: {this.name} ({this.value})\n* Desc: {this.desc}\n* Mod: {this.modifier}\n{bottom}";
        }
    }
}