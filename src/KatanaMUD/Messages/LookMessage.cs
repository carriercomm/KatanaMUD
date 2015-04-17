﻿using KatanaMUD.Models;
using System;

namespace KatanaMUD.Messages
{
    public class LookMessage : MessageBase
    {
        public Direction? Direction { get; set; }
        public int? Actor { get; set; }
        public int? Item { get; set; }
        public string YouFigureItOut { get; set; }

        public override void Process(Actor actor)
        {
            //TODO: Tell room about the user looking around.

            if (Direction != null)
            {
                var exit = actor.Room.GetExit(Direction.Value);
                //TODO
            }
            else if (Actor != null)
            {
                //TODO
            }
            else if (Item != null)
            {
                //TODO
            }
            else if (!String.IsNullOrWhiteSpace(YouFigureItOut))
            {
                //TODO
            }
            else
            {
                // TODO: Blind, etc.
                var roomMessage = new RoomDescriptionMessage();
                roomMessage.RoomId = actor.Room.Id;
                roomMessage.IsCurrentRoom = true;
                roomMessage.Description = actor.Room.TextBlock.Text;    //TODO: Settings->Brief
                roomMessage.Name = actor.Room.Name;
                //TODO: Actors
                //TODO: Items

                actor.SendMessage(roomMessage);
            }
        }
    }
}