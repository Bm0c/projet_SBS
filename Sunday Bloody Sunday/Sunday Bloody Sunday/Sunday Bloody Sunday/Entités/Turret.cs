﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sunday_Bloody_Sunday
{
    class Turret
    {
        //FIELDS
        public Rectangle turretTexture;
        public Keys poserTurret;
        public bool isActive;
        public int munition;
        int reffroidissement = 0;



        //CONSTRUCTOR
        public Turret(int x, int y, Keys poserTurret)
        {
            this.turretTexture = new Rectangle(x, y, 16, 16);
            this.poserTurret = poserTurret;
            this.isActive = true;
            munition = 42;
        }


        //METHODS
        // Get the width of the turret
        public int Width
        {
            get { return turretTexture.Width; }
        }

        // Get the height of the turret
        public int Height
        {
            get { return turretTexture.Height; }
        }

        public Vector2 centre()
        {
            Vector2 vector = new Vector2(turretTexture.X + Width / 2, turretTexture.Y + Height / 2);
            return vector;
        }


        //UPDATE & DRAW
        public void Update(List<Player> liste_joueurs, List<IA> liste_ias, List<Projectile> liste_projectiles, Sound sons)
        {
            foreach (IA ia in liste_ias)
            {
                if (reffroidissement == 0 && munition > 0)
                {
                    if (ia.IATexture.Contains((int)centre().X, (int)ia.IATexture.Y))
                    {
                        if (ia.IATexture.Y < turretTexture.Y)
                            liste_projectiles.Add(new Projectile(Ressources.Projectile, (int)centre().X - 5, (int)centre().Y - 5, 10, Direction.Up, 50));
                        else
                            liste_projectiles.Add(new Projectile(Ressources.Projectile, (int)centre().X - 5, (int)centre().Y - 5, 10, Direction.Down, 50));
                        reffroidissement = 10;
                        munition--;
                        sons.PlaySentryShoot();
                    }
                    else if (ia.IATexture.Contains((int)ia.IATexture.X, (int)centre().Y))
                    {
                        if (ia.IATexture.X < turretTexture.X)
                            liste_projectiles.Add(new Projectile(Ressources.Projectile, (int)centre().X - 5, (int)centre().Y - 5, 10, Direction.Left, 50));
                        else
                            liste_projectiles.Add(new Projectile(Ressources.Projectile, (int)centre().X - 5, (int)centre().Y - 5, 10, Direction.Right, 50));
                        reffroidissement = 10;
                        munition--;
                        sons.PlaySentryShoot();
                    }
                }
            }
            if (reffroidissement > 0)
            {
                reffroidissement--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle MapTexture)
        {
            if (isActive)
            {
                spriteBatch.Draw(Ressources.mAmmoBox, new Rectangle(MapTexture.X + turretTexture.X, MapTexture.Y + turretTexture.Y, 16, 16), Color.White);
            }
        }
    }
}
