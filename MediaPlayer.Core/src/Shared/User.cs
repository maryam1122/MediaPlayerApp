using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Core.src.Shared
{
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int Id { get; set; }
    }

    public enum Role
    {
        Subscriber,
        Admin
    }
}