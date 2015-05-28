﻿using System;
using System.Collections.Generic;
using System.Linq;
using KatanaMUD;
using KatanaMUD.Messages;
using KatanaMUD.Models;
using KatanaMUD.Scripts;

public class RoomOfSilence : IRoomScript
{
    public void CanActorCommunicate(Room room, Actor actor, CommunicationType type, string message, Validation validation)
    {
        if (actor.User.AccessLevel != AccessLevel.Sysop && type == CommunicationType.Say)
        {
            validation.Fail("You open your mouth to speak, but the bishop casts a stern look at you, and you think it better to close your mouth.", null, nameof(RoomOfSilence));
        }
    }

    public void ActorCommunicated(Room room, Actor actor, CommunicationType type, string message) { }
    public void ActorEmoted(Room room, Actor actor, string emoteName, string target) { }
    public void CanActorEmote(Room room, Actor actor, string emoteName, string target, Validation validation) { }
    public void CanDropCash(Room room, Currency currency, long quantity, Actor actor, Validation validation) { }
    public void CanDropItem(Room room, Item item, Actor actor, Validation validation) { }
    public void CanGetCash(Room room, Currency currency, long quantity, Actor actor, Validation validation) { }
    public void CanGetItem(Room room, Item item, Actor actor, Validation validation) { }
    public void CanHideCash(Room room, Currency currency, long quantity, Actor actor, Validation validation) { }
    public void CanHideItem(Room room, Item item, Actor actor, Validation validation) { }
    public void CanPartyEnter(Room room, Party party, Validation validation) { }
    public void CanPartyLeave(Room room, Party party, Validation validation) { }
    public void CanActorAttack(Room room, Actor attacker, IEnumerable<Actor> defenders, Validation validation) { }
    public void CashDropped(Room room, Currency currency, long quantity, Actor actor) { }
    public void CashGotten(Room room, Currency currency, long quantity, Actor actor) { }
    public void CashHidden(Room room, Currency currency, long quantity, Actor actor) { }
    public void ItemDropped(Room room, Item item, Actor actor) { }
    public void ItemGotten(Room room, Item item, Actor actor) { }
    public void ItemHidden(Room room, Item item, Actor actor) { }
    public void PartyEntered(Room room, Party party) { }
    public void PartyLeft(Room room, Party party) { }
    public void ActorAttacks(Room room, Actor attacker, IEnumerable<Actor> defenders) { }
    public void ActorDied(Room room, Actor actor) { }
    public void ActorDropped(Room room, Actor actor) { }
    public void ActorDisconnected(Room room, Actor actor) { }
    public void ActorConnected(Room room, Actor actor) { }
}