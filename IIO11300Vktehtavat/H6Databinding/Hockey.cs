using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6Databinding
{
    public class HockeyPlayer : INotifyPropertyChanged
    {
        #region PROPERTIES
        private string name;
        public string Name
        {
            set
            {
                name = value;
                Notify("Name");
                Notify("NameAndNumber");
            }
            get
            {
                return name;
            }
        }
        private string number;
        public string Number
        {
            set
            {
                number = value;
                Notify("Number");
                Notify("NameAndNumber");
            }
            get
            {
                return number;
            }
        }
        public string NameAndNumber
        {
            get { return name + "#" + number; }
        }
        #endregion

        #region CONSTRUCTORS
        public HockeyPlayer()
        {

        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }

        #endregion

        #region METHODS
        public override string ToString()
        {
            return name + "#" + number;
        }

        //INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
    public class HockeyTeam
    {
        #region PROPERTIES
        //huom public field ei kelpaa WPF:n databindingissa, pitää olla property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "";
            City = "Unknown";
        }
        public HockeyTeam(string name, string city)
        {
            Name = name;
            City = city;
        }
        #endregion
        public override string ToString()
        {
            return Name + "@" + City;
        }
    }

    public class HockeyLeague
    {
        //perustetaan SMLiiga, sisältää x kpl joukkueita
        List<HockeyTeam> teams = new List<HockeyTeam>();
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
            teams.Add(new HockeyTeam("Sport", "Vaasa"));
        }
        //metodi joka palauttaa Liigan joukkueet
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}

