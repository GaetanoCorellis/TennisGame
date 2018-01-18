using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisGame.Class {
    public class Player {
        public string Name { get; private set; }
        public ushort Points { get; set; }
        public Player(string name) {
            Name = name;
            Points = 0;
        }
    }
}
