using System;
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
    class Map
    {

        Reseau Client = new Reseau();
        Reseau Serveur = new Reseau();

        int seed= 0;

        string message = "";
        string message_2 = "";
        // FIELDS
        Rectangle MapTexture;
        public List<Spawn> spawns;
        public Spawn_Items spawn_items;

        bool testc = true;
        bool joue_son = true;

        public List<Items> liste_box; //Liste Items
        public List<Items> liste_box2; //Liste Items secondaire, utilisée pour nettoyer la mémoire

        public List<DestructibleItems> liste_barrel; //Liste barrels
        public List<DestructibleItems> liste_barrel2; //Liste barrels secondaire

        public List<ParticuleExplosion> liste_explosions; //Liste particules d'explosion
        public List<ParticuleExplosion> liste_explosions2; //Liste particules d'explosion secondaire
        public List<ParticuleExplosion> liste_explosions3;

        public List<ParticuleExplosion> liste_blood; //Liste particules sang
        public List<ParticuleExplosion> liste_blood2; //Liste particules sang secondaire

        public List<ParticuleRain> liste_rain; //Liste rain

        public List<Player> liste_joueurs = new List<Player>(); //Liste joueurs
        public List<Player> liste_joueurs2 = new List<Player>(); //Liste joueurs secondaire

        public List<IA> liste_ia; //Liste des IA
        public List<IA> liste_ia2; //Liste IA secondaire

        public List<Keys> liste_clavier;
        public List<Keys> liste_clavier_2;

        public List<Projectile> liste_projectile = new List<Projectile>(); //Liste Projectiles
        public List<Projectile> liste_projectile2 = new List<Projectile>(); //Liste Projectiles secondaire

        public List<Turret> liste_turret; //Liste Turrets
        public List<Turret> liste_turret2; //Liste Turrets secondaire

        Projectile balle;
        IA ia;
        Texture2D explosionTexture, rainTexture;
        float spawnWidth = Divers.WidthScreen, density = 35, timer;
        PhysicsEngine map_physique;
        private Rectangle futur_rectangle; //Rectangle utilisé pour stocker des données
        int compteur = 0;
        Random rand0 = new Random();
        Random rand1 = new Random();
        Random rand2 = new Random();
        Sound moteur_son = new Sound();

        bool etape1 = false;
        bool etape2 = false;
        bool etape3 = true;

        public bool game_over = false;
        Param_Map parametre;
        public CheckPoint fin_niveau, boss_entry;
        int compteur_kill = 0;


        // CONSTRUCTOR
        public Map(Param_Map parametre)
        {
            this.parametre = parametre;

            MapTexture = new Rectangle(0, 0, parametre.hauteur * 16, (parametre.largeur - 1) * 16);
            this.map_physique = new PhysicsEngine(parametre.liste, parametre.liste_projectile);
            this.liste_ia = new List<IA>();
            if (parametre.texture_map == 3)
            {
                Player p1 = new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.N, Keys.P, Keys.Enter, Keys.T, Ressources.Player1, parametre.x, parametre.y);
                Player p2 = new Player(Keys.Z, Keys.S, Keys.Q, Keys.D, Keys.A, Keys.E, Keys.R, Keys.W, Ressources.Player2, parametre.x, parametre.y);
                p1.bomb = 5;
                p2.bomb = 5;
                liste_joueurs.Add(p1);
                liste_joueurs.Add(p2);
            }
            else
            {
                this.liste_joueurs.Add(new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.N, Keys.P, Keys.Enter, Keys.T, Ressources.Player1, parametre.x, parametre.y));
            }

            //HEALTH + AMMO BOXES
            this.liste_box = new List<Items>();
            this.liste_box2 = new List<Items>();

            //EXPLOSIVE BOXES
            this.liste_barrel = new List<DestructibleItems>();
            this.liste_barrel = parametre.liste_barrel;

            //EXPLOSION PARTICULE
            this.liste_explosions = new List<ParticuleExplosion>();
            this.liste_explosions2 = new List<ParticuleExplosion>();
            this.liste_explosions3 = new List<ParticuleExplosion>();
            this.explosionTexture = Ressources.ExplosionParticule;

            //BLOOD PARTICULE
            this.liste_blood = new List<ParticuleExplosion>();
            this.liste_blood2 = new List<ParticuleExplosion>();

            //TURRETS
            this.liste_turret = new List<Turret>();
            this.liste_turret2 = new List<Turret>();

            //RAIN (que sur la map01)
            this.liste_rain = new List<ParticuleRain>();
            this.rainTexture = Ressources.mRain;

            this.spawns = parametre.liste_spawn;
            this.spawn_items = parametre.liste_caisses;

            this.liste_clavier = new List<Keys>();
            this.liste_clavier_2 = new List<Keys>();

            fin_niveau = parametre.checkpointArrivee;
            boss_entry = parametre.checkpointBossEntry;

            if (etape3)
            {
                Client.initialisationClient(4242);
                Serveur.intialisationServeur(1338);
            }
        }


        // METHODS
        //Verifie la possibilité des actions de l'IA
        //Ces deux actions sont similaires à celles du héros
        //Gère le deplacement de l'ia
        public void pathfing(ref string action, Player joueur)
        {

            if (ia.compteur_path % 30 == 0)
            {
                ia.compteur_path = 0;
                ia.ia_dir = seed % 2;
            }

            ia.compteur_path++;

            if (ia.ia_dir == 0)
            {
                if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                {
                    action = "left";
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {
                            action = "up";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                {
                    action = "right";
                    if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        action = "up";
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {

                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                {
                    action = "up";

                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                {
                    action = "down";
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }

                    }
                }
            }
            else
            {

                if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                {
                    action = "up";

                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                {
                    action = "down";
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }

                    }
                }
                else if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                {
                    action = "left";
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {
                            action = "up";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                {
                    action = "right";
                    if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        action = "up";
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {

                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
            }

        }

        public void pathfing_vol(ref string action, Player joueur)
        {

            if (ia.compteur_path % 30 == 0)
            {
                ia.compteur_path = 0;
                ia.ia_dir = seed % 2;
            }

            ia.compteur_path++;

            if (ia.ia_dir == 0)
            {
                if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                {
                    action = "left";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {
                            action = "up";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                {
                    action = "right";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        action = "up";
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {

                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                {
                    action = "up";

                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                {
                    action = "down";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }

                    }
                }
            }
            else
            {

                if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                {
                    action = "up";

                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                {
                    action = "down";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                        {
                            action = "left";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                        {
                            action = "right";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                                 && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }

                    }
                }
                else if (joueur.PlayerTexture.X < this.ia.IATexture.X)
                {
                    action = "left";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {
                            action = "up";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
                else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
                {
                    action = "right";
                    if (!(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                    {
                    }
                    else
                    {
                        action = "up";
                        if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                        {

                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                        else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                        {
                            action = "down";
                            if (!(map_physique.mur_projectile(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                             && !(map_physique.mur_projectile(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                            {
                            }
                            else
                            {
                                action = "";
                            }
                        }
                    }
                }
            }
        }

        //Gère le raffraichissement de la liste d'IA
        public void update_ia()
        {
            foreach (IA ia in liste_ia) //Pour chaque IA de la liste
            {
                if (ia.Health > 0)
                {
                    ia.est_update = true; //Précise que l'on travaille sur la liste
                    this.ia = ia;
                    float distance = 10000;
                    Vector2 vector_ia = new Vector2(ia.IATexture.X, ia.IATexture.Y);
                    Player joueur_cible = new Player(Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.S, Keys.P, Keys.Enter, Keys.T, Ressources.Player1, parametre.x, parametre.y);
                    Vector2 vector_joueur = new Vector2();
                    foreach (Player joueur in liste_joueurs)
                    {
                        joueur_cible = joueur;
                        vector_joueur = new Vector2(joueur_cible.PlayerTexture.X, joueur_cible.PlayerTexture.Y);
                    }

                    Vector2.Distance(ref vector_ia, ref vector_joueur, out distance);
                    foreach (Player joueur in liste_joueurs)
                    {
                        vector_joueur = new Vector2(joueur.PlayerTexture.X, joueur.PlayerTexture.Y);
                        float distance_2;
                        Vector2.Distance(ref vector_ia, ref vector_joueur, out distance_2);
                        if (distance_2 < distance)
                        {
                            distance = distance_2;
                            joueur_cible = joueur;
                        }
                    }
                    //L'ensemble des commandes précédentes définissent quel héros est la cible, ici le plus proche
                    /*
                    Node départ = new Node();
                    départ.x = (this.ia.IATexture.X + 8) / 16;
                    départ.y = (this.ia.IATexture.Y + 8) / 16;
                    Node arrivée = new Node();
                    arrivée.x = (joueur_cible.PlayerTexture.X + 8) / 16;
                    arrivée.y = (joueur_cible.PlayerTexture.Y + 8) / 16;

                    bool[,] map = map_physique.map();*/
                    /*
                    this.ia.action = Pathfinding.pathfind(map, départ, arrivée);
                    */
                    if (ia.ia_vol)
                    {
                        pathfing_vol(ref this.ia.action, joueur_cible);
                    }
                    else
                    {
                        pathfing(ref this.ia.action, joueur_cible);
                    }
                    //Trouve quelle action va faire l'IA
                    ia.action_ia(ia, joueur_cible, liste_barrel, map_physique, liste_ia, liste_joueurs); //Verifie la possibilité de réalisation des actions
                    ia.Update(); //Met à jour l'IA
                    ia.attaque_ia(liste_joueurs);
                    ia.est_update = false; //Désactive l'update de l'IA
                }
                else
                {
                    ia.en_vie = false; //Tue l'IA
                    compteur_kill++;
                    AddBloodEffect(new Vector2(ia.IATexture.X, ia.IATexture.Y), ia.IATexture.X, ia.IATexture.Y, 1);
                    moteur_son.PlayBloodEffect();
                }
            }
            if (compteur > 180 && etape1) //Ajout de nouvelles IA a la map
            {

                int choix = seed % spawns.Count; ;
                Spawn spawn = spawns.ElementAt(choix);
                choix = seed % spawn.créatures.Count;

                IA ia = spawn.créatures.ElementAt(choix);
                IA ia_ = new IA(ia.IATexture.X, ia.IATexture.Y, ia.id_son, ia.id_texture, ia.Health, ia.Damage);


                float distance = 10000;
                Vector2 vector_ia = new Vector2(ia_.IATexture.X, ia_.IATexture.Y);
                Player joueur_cible = new Player(Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.S, Keys.P, Keys.Enter, Keys.T, Ressources.Player1, parametre.x, parametre.y);
                Vector2 vector_joueur = new Vector2();
                foreach (Player joueur in liste_joueurs)
                {
                    joueur_cible = joueur;
                    vector_joueur = new Vector2(joueur_cible.PlayerTexture.X, joueur_cible.PlayerTexture.Y);
                }

                Vector2.Distance(ref vector_ia, ref vector_joueur, out distance);
                foreach (Player joueur in liste_joueurs)
                {
                    vector_joueur = new Vector2(joueur.PlayerTexture.X, joueur.PlayerTexture.Y);
                    float distance_2;
                    Vector2.Distance(ref vector_ia, ref vector_joueur, out distance_2);
                    if (distance_2 < distance)
                    {
                        distance = distance_2;
                    }
                }
                if (distance < 400)
                {
                    bool test = true;
                    foreach (IA ia__ in liste_ia)
                    {
                        if (ia__.IATexture.Intersects(ia_.IATexture))
                        {
                            test = false;
                        }
                        else
                        {
                        }
                    }
                    if (test)
                    {
                        liste_ia.Add(ia_);
                        if (true)
                        {
                            moteur_son.PlayPika(ia_.id_son);
                        }

                        joue_son = !joue_son;
                        compteur = 0;
                    }
                }
            }
            compteur = compteur + 1;

            liste_ia2 = new List<IA>(); //Recopie la liste d'IA encore en vie dans une nouvelle liste
            foreach (IA ia in liste_ia)
            {
                if (ia.en_vie)
                    liste_ia2.Add(ia);
            }
            liste_ia = liste_ia2; //Vide la liste secondaire dans la premiere
        }

        public void update_projectiles(KeyboardState keyboard)
        {
            foreach (Projectile balle in liste_projectile)
            {
                balle.init = 0;
            }

            foreach (Projectile balle in liste_projectile)
            {
                while ((balle.init < balle.projectileMoveSpeed) && balle.isVisible)
                {
                    balle.collision_entite_balle(liste_ia); //Collision entres balles et entité
                    balle.collision_balle(map_physique); //Collision entre balle et mur
                    collision_barrel_balle(balle);
                    balle.init++; //On bouge la balle d'une case
                }
            }

            foreach (Player joueur in liste_joueurs) //On ajoute des balles en fonction des touches et du refroidissement
            {
                if ((joueur.tir && joueur.refroidissement >= 12 && etape1 && joueur.Ammo > 0))
                {
                    balle = new Projectile(Ressources.Projectile, (int)joueur.centre().X, (int)joueur.centre().Y, 10, joueur.Direction, 50);
                    liste_projectile.Add(balle);
                    joueur.refroidissement = 0;
                    joueur.Ammo = joueur.Ammo - 1;
                    moteur_son.PlayTire();
                }
                joueur.refroidissement++;
            }

            liste_projectile2 = new List<Projectile>(); //On nettoie la liste, comme avec les IA
            foreach (Projectile balle in liste_projectile)
            {
                if (balle.isVisible)
                    liste_projectile2.Add(balle);
            }
            liste_projectile = liste_projectile2;
        }

        public void update_Box()
        {
            foreach (Items box in liste_box)
            {
                box.Update(liste_joueurs);
            }
            liste_box2 = new List<Items>();
            foreach (Items box in liste_box)
            {
                if (box.isVisible)
                {
                    liste_box2.Add(box);
                }
            }
            liste_box = liste_box2;

            if (compteur > 180) //Ajout de nouveaux "barrels" a la map
            {
                Items box;
                int spawn = seed % spawn_items.emplacement.Count;
                int texture = seed % 2;
                Vector2 emplacement = spawn_items.emplacement.ElementAt(spawn);
                bool test = true;
                if (texture == 0)
                {
                    box = new Items((int)emplacement.X, (int)emplacement.Y, "health");
                    foreach (Items box_ in liste_box)
                    {
                        if ((box_.HealthBoxTexture.Intersects(box.HealthBoxTexture)) && test)
                        {
                            test = false;
                        }
                    }
                    if (test)
                        liste_box.Add(box);
                }
                else
                {

                    box = new Items((int)emplacement.X, (int)emplacement.Y, "ammo");
                    foreach (Items box_ in liste_box)
                    {
                        if ((box_.HealthBoxTexture.Intersects(box.HealthBoxTexture)) && test)
                        {
                            test = false;
                        }
                    }
                    if (test)
                        liste_box.Add(box);
                }
                if (test)
                {
                    moteur_son.PlayPop();

                    compteur = 0;
                }
            }

            compteur++;
        }

        public void update_Bomb(List<Player> liste_joueurs, KeyboardState keyboard)
        {
            foreach (Player joueur in liste_joueurs)
            {
                if (parametre.texture_map == 3)
                {
                    if (joueur.poserBomb && joueur.refroidissement > 30 && joueur.bomb > 0)
                    {

                        AddBomb(joueur.PlayerTexture.X, joueur.PlayerTexture.Y, joueur.ActiverBomb);
                        joueur.refroidissement = 0;
                        joueur.bomb--;
                    }
                }
                else
                {
                    if (joueur.poserBomb && joueur.bomb > 0)
                    {
                        AddBomb(joueur.PlayerTexture.X, joueur.PlayerTexture.Y, joueur.ActiverBomb);
                        joueur.bomb--;
                    }
                }
            }

            foreach (DestructibleItems bomb in liste_barrel)
            {
                if (bomb.type == "bomb")
                {
                    bool test = false;
                    if (parametre.texture_map != 3)
                    {
                        test = keyboard.IsKeyDown(bomb.déclencher);
                        foreach (Keys key in liste_clavier)
                        {
                            if (key == bomb.déclencher)
                            {
                                test = true;
                            }
                        }

                        if (test)
                        {
                            AddExplosion(new Vector2(bomb.BombTexture.X + 8, bomb.BombTexture.Y + 8), bomb.Aire_barrel.X - 16, bomb.Aire_barrel.Y - 16, 48);
                            moteur_son.PlayExplosionEffect();
                            bomb.isVisible = false;
                        }
                    }
                }

                else if (bomb.type == "bomb_2")
                {
                    foreach (Player joueur in liste_joueurs)
                    {
                        if ((keyboard.IsKeyDown(bomb.déclencher) && joueur.ActiverBomb == bomb.déclencher) || bomb.detonnateur == 0)
                        {
                            joueur.bomb = 5;
                            AddExplosion(new Vector2(bomb.BombTexture.X + 8, bomb.BombTexture.Y + 8), bomb.Aire_barrel.X - 16, bomb.Aire_barrel.Y - 16, 48);
                            moteur_son.PlayExplosionEffect();
                            bomb.isVisible = false;
                        }
                    }
                    bomb.detonnateur--;
                }
            }
        }

        public void AddBloodEffect(Vector2 position, int x, int y, int largeur)
        {
            ParticuleExplosion blood = new ParticuleExplosion();
            blood.Initialize(Ressources.BloodParticule, position, 150, 186, 12, 45, Color.White, 1f, false, x, y, largeur, "blood");
            liste_blood.Add(blood);
        }

        public void update_Blood(GameTime gameTime)
        {
            liste_blood2 = new List<ParticuleExplosion>();

            foreach (ParticuleExplosion blood in liste_blood)
            {
                blood.Update(gameTime, liste_joueurs, liste_ia, liste_barrel, liste_explosions, liste_explosions3, liste_blood);
                if (blood.Active == true)
                {
                    liste_blood2.Add(blood);
                }
            }
            foreach (ParticuleExplosion prout in liste_explosions3)
            {
                liste_blood2.Add(prout);
            }
            liste_blood = liste_blood2;
        }

        public void update_Barrel(KeyboardState keyboard)
        {
            foreach (DestructibleItems barrel in liste_barrel)
            {
                barrel.Update(liste_joueurs, keyboard, liste_barrel);
            }
            liste_barrel2 = new List<DestructibleItems>();
            foreach (DestructibleItems barrel in liste_barrel)
            {
                if (barrel.isVisible)
                {
                    liste_barrel2.Add(barrel);
                }
            }
            liste_barrel = liste_barrel2;
        }

        public void collision_barrel_balle(Projectile balle) //S'occupe de la collision des balles avec les "barrels"
        {
            futur_rectangle = balle.rectangle();
            bool test = true;
            foreach (DestructibleItems barrel in liste_barrel) //Vérifie pour chaque "barrels"
            {
                if ((test)) //Permet de casser la boucle dès qu'un "barrel" est touché
                {
                    if (futur_rectangle.Intersects(barrel.Aire_barrel) && barrel.type == "barrel") //Si la HitBox du projectile est en contact avec celle du "barrel", alors (...)
                    {
                        balle.isVisible = false; //La balle n'existe plus
                        barrel.isVisible = false; //Le "barrel" n'existe plus
                        AddExplosion(new Vector2(barrel.Aire_barrel.X + 8, barrel.Aire_barrel.Y + 8), barrel.Aire_barrel.X - 16, barrel.Aire_barrel.Y - 16, 48);
                        moteur_son.PlayExplosionEffect();
                        test = false; //On casse le si
                    }
                }
            }
        }

        public void AddExplosion(Vector2 position, int x, int y, int largeur)
        {
            ParticuleExplosion explosion = new ParticuleExplosion();
            explosion.Initialize(Ressources.ExplosionParticule, position, 134, 134, 12, 45, Color.White, 1f, false, x, y, largeur, "explosion");
            liste_explosions.Add(explosion);
        }

        public void update_Explosion(GameTime gameTime)
        {
            liste_explosions2 = new List<ParticuleExplosion>();
            liste_explosions3 = new List<ParticuleExplosion>();
            foreach (ParticuleExplosion explosion in liste_explosions)
            {
                explosion.Update(gameTime, liste_joueurs, liste_ia, liste_barrel, liste_explosions, liste_explosions3, liste_blood);
                if (explosion.Active == true)
                {
                    liste_explosions2.Add(explosion);
                }
            }
            foreach (ParticuleExplosion explosion in liste_explosions3)
            {
                liste_explosions2.Add(explosion);
            }
            liste_explosions = liste_explosions2;
        }

        public void AddBomb(int x, int y, Keys activer)
        {
            DestructibleItems bomb;
            if (parametre.texture_map != 3)
            {
                 bomb = new DestructibleItems(x, y, "bomb", activer);
            }
            else
            {
                 bomb = new DestructibleItems(x, y, "bomb_2", activer);
            }
            liste_barrel.Add(bomb);
        }

        public void AddTurret(int x, int y, Keys poserTurret)
        {
            Turret turret = new Turret(x, y, poserTurret);
            liste_turret.Add(turret);
        }

        public void update_turret(List<Player> liste_joueurs, KeyboardState keyboard)
        {
            foreach (Player joueur in liste_joueurs)
            {
                if (joueur.poserTurret && joueur.turret > 0)
                {
                    AddTurret(joueur.PlayerTexture.X, joueur.PlayerTexture.Y, joueur.PoserTurret);
                    moteur_son.PlaySentryReady();
                    joueur.turret--;
                }
            }
            foreach(Turret sentry in liste_turret)
            {
                sentry.Update(liste_joueurs, liste_ia, liste_projectile,moteur_son);
            }
        }

        public void AddRain()
        {
            liste_rain.Add(new ParticuleRain(rainTexture, new Vector2(-50 + (float)rand1.NextDouble() * spawnWidth, 0), new Vector2(1, rand2.Next(5, 8))));
        }

        public void update_Rain(GameTime gameTime, GraphicsDevice graphics)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (timer > 0)
            {
                timer -= 1f / density;
                AddRain();
            }

            for (int i = 0; i < liste_rain.Count; i++)
            {
                liste_rain[i].Update();

                if (liste_rain[i].Position.Y > graphics.Viewport.Height)
                {
                    liste_rain.RemoveAt(i);
                    i--;
                }
            }
        }

        //Gère l'affichage de la liste d'IA
        public void swap(ref IA a, ref IA b)
        {
            IA c = a;
            a = b;
            b = c;
        }

        public int minimum(IA[] tableau, int d, int f)
        {
            int pos = d;
            int i = d + 1;
            while (i < tableau.Length)
            {
                if (tableau[i].IATexture.Y < tableau[pos].IATexture.Y)
                {
                    pos = i;
                }
                i++;
            }

            return pos;
        }

        public void tri(ref IA[] tableau)
        {
            int i = 0;
            while (i < tableau.Length)
            {
                swap(ref tableau[i], ref tableau[minimum(tableau, i, tableau.Length)]);
                i++;
            }
        }

        public void draw_ordre(SpriteBatch spriteBatch)
        {
            IA[] tableau_ia = new IA[liste_ia.Count];
            liste_ia.CopyTo(tableau_ia);
            tri(ref tableau_ia);
            foreach (Player joueur in liste_joueurs)
            {
                joueur.est_afficher = false;
            }
            foreach (IA ia in tableau_ia)
            {
                foreach (Player joueur in liste_joueurs)
                {
                    if ((ia.IATexture.Y > joueur.PlayerTexture.Y) && !joueur.est_afficher)
                    {
                        joueur.Draw(spriteBatch, MapTexture);
                        joueur.est_afficher = true;

                    }

                    ia.Draw(spriteBatch, MapTexture);
                }


            }
            foreach (Player joueur in liste_joueurs)
            {
                if (!joueur.est_afficher)
                {
                    joueur.Draw(spriteBatch, MapTexture);
                    joueur.est_afficher = true;
                }
            }
        }

        public void update_player(KeyboardState keyboard, MouseState mouse)
        {
            // Update l'objet joueur contenu par la map
            foreach (Player joueur in liste_joueurs)
            {
                joueur.Update(mouse, keyboard, liste_clavier);
                joueur.action_hero(map_physique, liste_ia, liste_barrel);
                if (joueur.Health > 0)
                {
                    liste_joueurs2.Add(joueur);
                }
                else
                {
                    if (parametre.texture_map == 3)
                    {
                        Player joueur_ = new Player(joueur.Haut, joueur.Bas, joueur.Gauche, joueur.Droite, joueur.Tire, joueur.PoserBomb, joueur.ActiverBomb, joueur.PoserTurret, joueur.texture, parametre.x, parametre.y);
                        joueur_.bomb = 5;
                        liste_joueurs2.Add(joueur_);
                    }
                }
            }
            liste_joueurs = liste_joueurs2;
            liste_joueurs2 = new List<Player>();

            if (keyboard.IsKeyDown(Keys.D1) && !etape1 && parametre.texture_map != 3)
            {
                etape1 = true;
            }

            if (keyboard.IsKeyDown(Keys.D2) && !etape2 && parametre.texture_map != 3)
            {
                etape2 = true;
                this.liste_joueurs.Add(new Player(Keys.Z, Keys.S, Keys.Q, Keys.D, Keys.A, Keys.E, Keys.R, Keys.W, Ressources.Player2, parametre.x, parametre.y));/*
                this.liste_joueurs.Add(new Player(Keys.NumPad8, Keys.NumPad5, Keys.NumPad4, Keys.NumPad6, Keys.NumPad7, Ressources.Player3));*/
            }

            if (keyboard.IsKeyDown(Keys.D3) && !etape3 && parametre.texture_map != 3)
            {
                etape3 = true;
            }

            if (liste_joueurs.Count == 0) //Si il n'y a plus de joueurs
            {
                game_over = true;
            }
        }

        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard, GameTime gameTime, GraphicsDevice graphics)
        {
            
            message = "0";
            if (Keyboard.GetState().IsKeyDown(Keys.Z))//Up
            {
                message = message + '1';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))//Down
            {
                message = message + '2';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))//Right
            {
                message = message + '3';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))//Left
            {
                message = message + '4';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))//Tir
            {
                message = message + '5';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))//Pose
            {
                message = message + '6';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))//Bombe
            {
                message = message + '7';
            }

            if (etape3)
            {
                seed = System.Convert.ToInt32(Serveur.receptionMessage());
                Client.envoieMessage(message);
                liste_clavier = Serveur.Liste(Serveur.receptionMessage());
            }
            else
            {
                seed = new Random().Next(1000);
            }
            

            testc = !testc;
            update_ia();
            update_Box();
            update_Barrel(keyboard);
            update_Explosion(gameTime);
            update_Blood(gameTime);
            update_projectiles(keyboard);
            update_player(keyboard, mouse);
            update_Bomb(liste_joueurs, keyboard);
            update_turret(liste_joueurs, keyboard);

            if (parametre.texture_map == 0)
            {
                Random rand3 = new Random();
                int i = rand3.Next(0, 5000);

                if (i == 42)
                {
                    moteur_son.PlayRainEffect();
                    density = 50;
                }
                update_Rain(gameTime, graphics);
                boss_entry.Update(liste_joueurs);
            }
            if (parametre.texture_map == 1)
            {
                fin_niveau.Update(liste_joueurs);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int x = 0;
            int y = 0;

            foreach (Player joueur in liste_joueurs)
            {
                x = joueur.PlayerTexture.X;
                y = joueur.PlayerTexture.Y;
            }
            if (parametre.scrolling)
            {
                MapTexture.X = 400 - x;
                MapTexture.Y = 240 - y;
            }
            else
            {
                MapTexture.X = 0;
                MapTexture.Y = 0;
            }
            if (parametre.texture_map == 0)
            {
                spriteBatch.Draw(Ressources.Map, this.MapTexture, Color.CadetBlue);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.LightGreen);
                boss_entry.Draw(spriteBatch, MapTexture);
                foreach (ParticuleRain rain in liste_rain)
                {
                    rain.Draw(spriteBatch);
                }
            }
            else if (parametre.texture_map == 1)
            {
                spriteBatch.Draw(Ressources.Map02, this.MapTexture, Color.CadetBlue);
                fin_niveau.Draw(spriteBatch, MapTexture);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.LightGreen);
            }
            else if (parametre.texture_map == 2)
            {
                spriteBatch.Draw(Ressources.Map03, this.MapTexture, Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.Orange);
            }
            else if (parametre.texture_map == 3)
            {
                spriteBatch.Draw(Ressources.Map03, this.MapTexture, Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.Orange);
            }
            foreach (Items box in liste_box)
            {
                box.Draw(spriteBatch, MapTexture);
            }
            foreach (DestructibleItems barrel in liste_barrel)
            {
                barrel.Draw(spriteBatch, MapTexture);
            }
            foreach (Turret sentryGun in liste_turret)
            {
                sentryGun.Draw(spriteBatch, MapTexture);
            }
            draw_ordre(spriteBatch);
            foreach (Projectile projectile in liste_projectile)
            {
                projectile.Draw(spriteBatch, MapTexture);
            }
            foreach (ParticuleExplosion blood in liste_blood)
            {
                blood.Draw(spriteBatch, MapTexture);
            }
            foreach (ParticuleExplosion explosion in liste_explosions)
            {
                explosion.Draw(spriteBatch, MapTexture);
            }
            if (parametre.texture_map == 1)
            {
                spriteBatch.Draw(Ressources.Map02_surcouche, this.MapTexture, Color.CadetBlue);
                fin_niveau.Draw(spriteBatch, MapTexture);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.LightGreen);
            }
            else if (parametre.texture_map == 2)
            {
                spriteBatch.Draw(Ressources.Map03surcouche, this.MapTexture, Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.Orange);
            }
            else if (parametre.texture_map == 3)
            {
                spriteBatch.Draw(Ressources.Map03surcouche, this.MapTexture, Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString(compteur_kill), new Vector2(5, 42), Color.Orange);
            }
        }
    }
}
