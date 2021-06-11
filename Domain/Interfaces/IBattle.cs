using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IBattle
    {
        public int Id { get; set; }
        public int GameId { set; get; }
        public Move MoveOne { set; get; }


    }
}
