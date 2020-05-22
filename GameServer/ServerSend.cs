using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer
{
    class ServerSend
    {
        public static Vector3 sphereP = new Vector3(0, 0, 0);
        public ServerSend instance;
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }

        #region Packets
        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void SpawnPlayer(int _toClient, Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);
                _packet.Write(_player.rotation);

                SendTCPData(_toClient, _packet);
            }
        }


        public static void PlayerPosition(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.positionM);

                SendUDPDataToAll(_player.id, _packet);
            }
        }

        public static void PlayerRotation(Player _player)
        {
            using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
            {
                _packet.Write(_player.id);
                _packet.Write(_player.rotation);

                SendUDPDataToAll(_player.id, _packet);
            }
        }

        public static void SpherePosition2(Player _sphere)
        {
            using (Packet _packet = new Packet((int)ServerPackets.spherePosition2))
            {
                int compare = _sphere.id;
               

                if (compare == 1)
                {

                    sphereP = _sphere.spherePosition;
                    _packet.Write(_sphere.id);
                    _packet.Write(_sphere.spherePosition);

                    SendUDPDataToAll(_sphere.id, _packet);
                    SendUDPDataToAll(2, _packet);

                }
               /* if (compare == 1)
                {

                    _packet.Write(_sphere.id);
                    _packet.Write(sphereP);

                    Console.WriteLine(sphereP);
                   
                    

                    SendUDPDataToAll(_sphere.id, _packet);

                }*/
            }
        }

        public static void SphereRotation2(Player _sphere)
        {
            using (Packet _packet = new Packet((int)ServerPackets.sphereRotation2))
            {
                int compare = _sphere.id;
                if (compare == 2)
                {
                    _packet.Write(_sphere.id);
                    _packet.Write(_sphere.sphereRotation);


                }
            }
        }
        #endregion
    }
}