using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;

namespace Trainer
{
    public class Main : Script
    {
        Vehicle car;
        bool isInvincible;
        bool infAmmo;
        bool infAmmoInClip;

        public Main()
        {
            UI.ShowHelpMessage("Welcome, Player!");
            UI.ShowSubtitle("~g~[+] ~s~Script loaded, Enjoy!");
            Tick += onTick;
            KeyDown += onKeyDown;
        }

        private void onTick(object sender, EventArgs e)
        {
            
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad0)
            {

                if (e.Control)
                {
                    if (infAmmoInClip)
                    {
                        Game.Player.Character.Weapons.Current.InfiniteAmmoClip = true;
                        UI.ShowSubtitle("~g~[+] Turned on infinite ammo in clip!");
                    }
                    else
                    {
                        Game.Player.Character.Weapons.Current.InfiniteAmmoClip = false;
                        UI.ShowSubtitle("~g~[+] Turned off infinite ammo in clip!");
                    }
                    infAmmoInClip = !infAmmoInClip;

                }
                else
                {
                    if (isInvincible)
                    {
                        Game.Player.Character.Health = 200;
                        Game.Player.IsInvincible = false;
                        UI.ShowSubtitle("~g~[+] Player ~s~is no longer ~g~invincible!");
                    }
                    else
                    {
                        Game.Player.Character.Health = 200;
                        Game.Player.IsInvincible = true;
                        UI.ShowSubtitle("~g~[+] Player ~s~is ~g~invincible!");
                    }

                    isInvincible = !isInvincible;
                }
            }

            if (e.KeyCode == Keys.NumPad1)
            {

                if (e.Control)
                {
                    if (infAmmo)
                    {
                        Game.Player.Character.Weapons.Current.InfiniteAmmo = true;
                        UI.ShowSubtitle("~g~[+] Turned on infinite ammo!");
                    }
                    else
                    {
                        Game.Player.Character.Weapons.Current.InfiniteAmmo = false;
                        UI.ShowSubtitle("~g~[+] Turned off infinite ammo!");
                    }
                    infAmmo = !infAmmo;

                }
                else
                {
                    car = World.CreateVehicle(VehicleHash.ItaliRSX, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)));
                    UI.ShowSubtitle("~g~[+] Itali RSX ~s~has been ~g~spawned!");
                }

            }

            if (e.KeyCode == Keys.NumPad2)
            {

                if (e.Control)
                {
                    Game.Player.Money += 1000;
                    UI.ShowSubtitle("~g~[+] Added $1000");
                }
                else
                {
                    car = World.CreateVehicle(VehicleHash.Reever, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)));
                    UI.ShowSubtitle("~g~[+] Reever ~s~has been ~g~spawned!");
                } 
            }

            if (e.KeyCode == Keys.NumPad3)
            {
                if (e.Control)
                {
                    if (Game.Player.WantedLevel == 5)
                    {
                        UI.ShowSubtitle("~r~[-] Max wanted level reached! Cannot increase wanted level!");
                    }
                    else
                    {
                        Game.Player.WantedLevel++;
                        UI.ShowSubtitle("~g~[+] Raised wanted level!");
                    }
                }
                else
                {
                    if (Game.Player.WantedLevel == 0)
                    {
                        UI.ShowSubtitle("~r~[+] You are not wanted!");
                    }
                    else if (Game.Player.WantedLevel < 6)
                    {
                        Game.Player.WantedLevel = 0;
                        UI.ShowSubtitle("~g~[+] Wanted level cleared!");
                    }
                }
            }

            if (e.KeyCode == Keys.NumPad4)
            {
                car = World.CreateVehicle(VehicleHash.Annihilator, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)));
                UI.ShowSubtitle("~g~[+] Annihilator ~b~has been ~g~spawned!");
            }

            if (e.KeyCode == Keys.NumPad5)
            {
                if (Game.Player.Character.Armor == 0)
                {
                    Game.Player.Character.Armor = 200;
                    UI.ShowSubtitle("~g~[+] Added Armor!");
                }
                else if (Game.Player.Character.Armor == 100)
                {
                    UI.ShowSubtitle("~r~[-] You already have max amount of armor!");
                }
            }

            if (e.KeyCode == Keys.NumPad6)
            {
                Game.Player.Character.Weapons.Give(WeaponHash.AssaultRifle, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.AssaultShotgun, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.AdvancedRifle, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.CombatPistol, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.CombatMG, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.Flare, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.GrenadeLauncher, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.Grenade, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.HeavySniper, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.HazardousJerryCan, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.Railgun, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.RPG, 10000, false, true);
                Game.Player.Character.Weapons.Give(WeaponHash.StickyBomb, 10000, false, true);
                UI.ShowSubtitle("~g~[+] Gave player guns!");
            }

            if (e.KeyCode == Keys.NumPad7)
            {
                Game.Player.RefillSpecialAbility();
                UI.ShowSubtitle("~g~[+] Refilled special ability!");
            }

            if (e.KeyCode == Keys.NumPad8)
            {
                World.CurrentDayTime = new TimeSpan(5, 30, 0);
                UI.ShowSubtitle("~g~Changed ~s~time to ~g~5:30");
            }

            if (e.KeyCode == Keys.NumPad9)
            {
                World.CurrentDayTime = new TimeSpan(24, 0, 0);
                UI.ShowSubtitle("~g~Changed ~s~time to ~g~12:00");
            }

            if (e.KeyCode == Keys.F12)
            {
                UI.Notify("~s~Help:\n" +
                    "NumPad 0 = Invincibility\n" +
                    "NumPad 1 = Spawn Itali RSX\n" +
                    "NumPad 2 = Spawn Reever\n" +
                    "NumPad 3 = Remove Wanted Level\n" +
                    "NumPad 4 = Spawn Annihilator\n" +
                    "NumPad 5 = Add armor\n" +
                    "NumPad 6 = Spawn guns\n" +
                    "NumPad 7 = Refill special ability\n" +
                    "NumPad 8 = Change time to 5:30 AM\n" +
                    "NumPad 9 = Change time to 12:00 AM\n" +
                    "CTRL + NumPad 0 = Infinite ammo in clip\n" +
                    "CTRL + NumPad 1 = Infinite ammo\n" +
                    "CTRL + NumPad 2 = Add money\n" +
                    "CTRL + NumPad 3 = Raise wanted level\n");
            }
        }
    }
}