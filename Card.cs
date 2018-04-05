using System;

namespace Hackathon_Day {
    public class Card {
        public int id;
        public int value;
        public string name;
        public string suit;
        public string desc;
        public string modifier;

        public override string ToString(){
            // Console.WriteLine();
            string top = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒";
            string bottom = top;
            string spacer = "▒                            ▒";
            string cardImage = getCardImage(this.value);
            string desc = getDescription(top, this.desc);
            string cardName = $"▒({this.value}) {this.name}" + getEndLine(top, $"*({this.value}) {this.name}");
            return $"{top}\n{spacer}\n{cardName}\n{spacer}\n{cardImage}\n{spacer}\n{desc}\n{spacer}\n{bottom}";
        }

        public string getEndLine(string top, string compare){

            int spacesLen = (top.Length - compare.Length) - 1;
            // Console.WriteLine(top.Length);
            // Console.WriteLine(compare.Length);
            // Console.WriteLine(spacesLen);

            string endLine = new String(' ', spacesLen) + "▒";
            return endLine;
        }

        public string trunDesc(string top, string desc){
            desc = desc.Trim();

            if(desc.Length + 4 > top.Length){
                int mid = desc.Length/2;
                int end = desc.Length - mid;
                // Console.WriteLine(mid);
                // Console.WriteLine(end);
                string left = trunDesc(top, desc.Substring(0, mid));
                string right = trunDesc(top, desc.Substring(mid, end));
                return left+right;
            }else{
                return "▒ " + desc + getEndLine(top, "▒ " + desc) + "\n";
            }

        }

        public string getDescription(string top, string description){
            string descriptionStr = "▒ ";

            if(description.Length + 4 > top.Length){
                descriptionStr=trunDesc(top, description).ToString().TrimEnd(Environment.NewLine.ToCharArray());
            }else{
                descriptionStr+=description + getEndLine(top, descriptionStr + description);
            }

            return descriptionStr;
        }

        public string getCardImage(int cardVal){
            string[] cardImg = new string[8];
            cardImg[7] = @"▒           ░██░             ▒
▒           █░▒█             ▒
▒           ░░▓▒             ▒
▒        ░░▒▒▒▓▒▒▓▒▓         ▒
▒       ░▓░░░▓░▒▒▓█▓▒░       ▒
▒      ░▓█▓░░▓░▒▓█▒▓██▒░     ▒
▒    ░▓░░█▓░░░▓▓▓█ ▓▒▓▓▓     ▒
▒     ░░▓▓▓░▒░▓▓▓▓▒▒▓░       ▒
▒    ░▒▓░ ░▒▒░▒▒▓▓▒░         ▒
▒     ▒▒░▒▓▒▓▒▒▓▓▓░          ▒
▒     ░▒░░▓▓▒▒░▒▒▓█          ▒
▒        ██░░█▒███░          ▒
▒        ████░░████          ▒
▒        ████  █░░█          ▒
▒         ██▓   ███          ▒
▒        █▓█▒   ███░         ▒
▒         ██     ██          ▒
▒         ▓█     ░█░         ▒
▒      ░████      █▓         ▒";

            cardImg[4] = @"▒                            ▒
▒               ░░           ▒ 
▒               ░░▒▓░░       ▒  
▒               ░░▒░░        ▒   
▒   ░░░░   ░░█░░░░▓▓░        ▒
▒       ░░░░░███░█████░░     ▒
▒       ░░░░███▓▓██████▓▒░   ▒
▒           ░░░▓████▓████░░  ▒
▒           ░▒▓██▒░░▒░░      ▒
▒           ██▒███▓█░        ▒
▒           ██▒█████░        ▒
▒           ██▓█████▒        ▒
▒           ██▓██████        ▒
▒           ░██░░░░██░       ▒
▒           ░██░  ░██▒       ▒
▒            ██   ░██░       ▒
▒           ░█░    ▓█░       ▒
▒           ░░░   ░░░░       ▒";
            
            cardImg[5] = @"▒               █            ▒
▒            ░██             ▒
▒            ▒██             ▒
▒           ░██████          ▒
▒          █▒▒░░░░           ▒
▒           ░░░░░░░          ▒
▒        ██▒░░░░░░▓          ▒
▒  ░ ░  ███░░░░░░░██    ░░░  ▒
▒   ░▒▒███░░░█░░▓░██▓██▓█    ▒
▒    █▒██ ██▒████▓████▒██    ▒
▒    ███  ██▒███▒██  ████    ▒
▒     █   ██▒██████    █     ▒
▒        ▒██░████▒█          ▒
▒        ███▒███▒█▓          ▒
▒        ██▒████▒██          ▒
▒       ███▒████▓█▓          ▒
▒       ███▒████▒█░          ▒
▒      ░▓██▒████▒██          ▒
▒      ███▓█████▓██          ▒
▒     ░███▒████████ ░        ▒
▒     ██░██████░   ██░       ▒";
            
            cardImg[3] = @"▒          ░▓▓ ▓             ▒
▒          ▓▓▓░              ▒
▒           ░ ░              ▒
▒         █    ▒░            ▒
▒       █░    ▓▒░░░          ▒
▒      █▒▒    ▓▓▒▒           ▒
▒    ░  ▓▒▓▓█▓▒▒▓█▓██        ▒
▒   █        ▓▒▒▓▓█▒▒▒       ▒
▒            ░██▒▒▒ ░▒▒      ▒
▒            ░▓▓▒░▒   ██     ▒
▒            ▓█████    ██    ▒ 
▒           ▓▒▒█▒▒░    █▓    ▒
▒          ░██▒█▓█▓▓         ▒
▒          ████ ░██▓         ▒
▒         ███▓   ░█▓░        ▒
▒         ▓██      █▓        ▒
▒         ░██       █▓       ▒
▒         ███   ░░  ███      ▒
▒      ░███▓▓▒░░░░░░░██      ▒
▒               ░░░▒▒███░    ▒";
            
            cardImg[6] = @"▒           ░░█████░░        ▒
▒       ░█▓▓▒▒▓▓▓▓▓▓▓▓▓█     ▒
▒       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░    ▒
▒       ░▓▓█▓▓▓▓░▓▓▓▓▓▓░     ▒
▒        █░█░░░░░░░░▒█       ▒
▒     █░░░▒░▒█▓▓▓▓█░█░░      ▒
▒    ▓▓▓▓░▒░░░░▒░░░░░█       ▒
▒    ▓▓▓▓  ▓░░░░░░░░█        ▒
▒   █▓▓▓▓▓░░░░░░░░░          ▒
▒    █▓▓▓▓▓▓▓▓█▓▓▓▓▓░█       ▒
▒       █▓▓▓▓▓▓▓▓▓▒▓▓▓░      ▒
▒         ░▓▓▓▓▓▓▓▓▓▓▓▒      ▒
▒         ░▓▓▓▓▓▓▓▓▓▓▓█      ▒
▒          ▓▓▓▓▓▓▓▓▓█▓█      ▒
▒          █▓▓▓▓█▓▓▓██░      ▒
▒          █▓▓▓▓▓▓▓▓██       ▒
▒          █▓▓▓▓▓▓▓▓█        ▒
▒          ░▓▓▓▓▓▓▓▓░        ▒
▒           █▒▒██▓▓█         ▒";
            
            cardImg[0] = @"▒           ░▒░░             ▒
▒          ▒█░░▓░            ▒
▒          ▓▒░▒▒░    ░░      ▒
▒          ▒▒░▒░   ░░▓░░     ▒
▒       ░░▒▓▒░░░░░░▒░░       ▒
▒      ▒▒▒░░░░░░░░▒░░░       ▒
▒     ▒█▓██▓░░░▒░▓██▓░       ▒
▒     ░▒█▒░░░░░▒▓░           ▒
▒         ░▒▒█░░▒▒░          ▒
▒        ░▓▒▒▒▒▒▒░▒          ▒
▒        ▓▓░█▒▒▒██░          ▒
▒        ▒▓▒█▓▒██▓░          ▒
▒        ▒█▒█▒▓▒███░         ▒
▒        ██▓█▒█▓██▒░         ▒
▒         ░███░███▒          ▒
▒          ███ ███░          ▒
▒         ░███░███           ▒
▒         ░▓█▓ ░██           ▒
▒          ░██ ░██           ▒
▒          ░██░▓░░░░░░       ▒
▒          ░░▒▓▓░░░          ▒";
            
            cardImg[2] = @"▒          ░███░             ▒
▒         ░█▒▒▒█░░▒          ▒
▒          ██▒██░  ▒▓        ▒
▒       ░░▓▒░▓▒░░   ░▒░      ▒
▒      ░██▓█▓▓▓▓▓░   ░▓▒░    ▒
▒     ░███░███████░▓▓█░░█    ▒
▒     ░█▓▓░ ███▓██▓▓█░       ▒
▒      ░███▓▒████▓█░░        ▒
▒         ░█▓█████▓          ▒
▒         ██████▓██░         ▒
▒        ░█████████          ▒
▒        ▓██▓█░███           ▒
▒         █▓█░░█▓░           ▒
▒        ███░ ███            ▒
▒       ▓███░███░            ▒
▒      ░███░ ███░            ▒
▒      ▓██░  ███             ▒
▒      ██░   ██░             ▒
▒     ░██    █████░          ▒
▒     ██░       ░            ▒";
            
            cardImg[1] = @"▒            ▒▓█             ▒
▒           ░▒▒▓█            ▒
▒           ░░▓▓▓░           ▒
▒        ░░░▓▒▒▒▒▒░░         ▒
▒      ░░▓▓▓█▓▓▓██▓▓░        ▒
▒     ░▒██████▒▓▒██▓▓        ▒
▒     ░░▓▒░░██████▓█▓        ▒
▒       ░▓▓███████░░░        ▒
▒       ░▒████████░          ▒
▒       ░███████▓██          ▒
▒       ░███████████         ▒
▒       ████████████░        ▒
▒      ░█████████████        ▒
▒      ██████████████░       ▒
▒     ░███████████████░      ▒
▒     ░███████████████░      ▒
▒     ▒████████████████░     ▒";

            return cardImg[cardVal];
        }
    }
}