﻿using Spam;
using System;
using System.Data.SqlClient;

namespace KatanaMUD.Models.Test
{
    public class Actor : Entity<Guid>
    {
        public override Guid Key
        {
            get { return Id; }
            set { Id = value; }
        }

        private Guid _id;
        private string _name;
        private string _surname;
        private int _actorType;
        private int _characterPoints;
        
        //private User _user;
        //private Room _room;
        //private ClassTemplate _classTemplate;
        private RaceTemplate _raceTemplate;

        public Actor()
        {
            Stats = new JsonContainer(this);
        }

        public Guid Id { get { return _id; } set { _id = value; this.Changed(); } }
        public string Name { get { return _name; } set { _name = value; this.Changed(); } }
        public string Surname { get { return _surname; } set { _surname = value; this.Changed(); } }
        public int ActorType { get { return _actorType; } set { _actorType = value; this.Changed(); } }
        public int CharacterPoints { get { return _characterPoints; } set { _characterPoints = value; this.Changed(); } }
        public dynamic Stats { get; private set; }

        public RaceTemplate RaceTemplate {
            get { return _raceTemplate; }
            set
            {
                ChangeParent(value, ref _raceTemplate, 
                    (RaceTemplate parent, Actor child) => parent.Actors.Remove(child), 
                    (RaceTemplate parent, Actor child) => parent.Actors.Add(child));
            }
        }

        public static Actor Load(SqlDataReader reader)
        {
            var entity = new Actor();
            entity.Id = reader.GetGuid(0);
            entity.Name = reader.GetSafeString(1);
            entity.Surname = reader.GetSafeString(2);
            entity.ActorType = reader.GetInt32(3);
            entity.CharacterPoints = reader.GetInt32(4);
            entity.Stats = new JsonContainer(entity);
            entity.Stats.FromJson(reader.GetSafeString(5));
            return entity;
        }

        private static void AddSqlParameters(SqlCommand c, Actor e)
        {
            c.Parameters.AddWithValue("@Id", e.Id);
            c.Parameters.AddWithValue("@Name", e.Name);
            c.Parameters.AddWithValue("@Surname", e.Surname);
            c.Parameters.AddWithValue("@ActorType", e.ActorType);
            c.Parameters.AddWithValue("@CharacterPoints", e.CharacterPoints);
            c.Parameters.AddWithValue("@JSONStats", e.Stats.ToJson());
            c.Parameters.AddWithValue("@RaceTemplateId", e.RaceTemplate?.Id);
        }

        public static void GenerateInsertCommand(SqlCommand c, Actor e)
        {
            c.CommandText = @"INSERT INTO [Actor] ([Id], [Name], [Surname], [ActorType], [CharacterPoints], [JSONStats], [RaceTemplateId])
                              VALUES (@Id, @Name, @Surname, @ActorType, @CharacterPoints, @JSONStats, @RaceTemplateId)";
            AddSqlParameters(c, e);
        }

        public static void GenerateUpdateCommand(SqlCommand c, Actor e)
        {
            c.CommandText = @"UPDATE [Actor] SET [Name] = @Name, [Surname] = @Surname, [ActorType] = @ActorType, [CharacterPoints] = @CharacterPoints, [JSONStats] = @JSONStats, [RaceTemplateId] = @RaceTemplateId
                              WHERE [Id] = @Id";
            AddSqlParameters(c, e);
        }

        public static void GenerateDeleteCommand(SqlCommand c, Actor e)
        {
            c.CommandText = @"DELETE FROM [Actor] WHERE [Id] = @Id";
            c.Parameters.AddWithValue("@Id", e.Id);
        }
    }
}