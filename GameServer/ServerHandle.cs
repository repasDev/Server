using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            Server.clients[_fromClient].SendIntoGame(_username);
        }

        public static void PlayerMovement(int _fromClient, Packet _packet)
        {
            Vector3 _positionM = _packet.ReadVector3();
            Quaternion _rotation = _packet.ReadQuaternion();

            //Console.WriteLine(_positionM);
            //Console.WriteLine(_rotation);

            Server.clients[_fromClient].player.SetInput(_rotation, _positionM);
        }

        public static void SphereMovement2(int _fromClient, Packet _packet)
        {
       
            Vector3 _spherePosition = _packet.ReadVector3();
            Quaternion _sphereRotation = _packet.ReadQuaternion();

            //Console.WriteLine(_spherePosition);
            //Console.WriteLine(_sphereRotation);
            //Console.WriteLine(_rotation);

            Server.clients[_fromClient].player.GetSphere(_spherePosition, _sphereRotation);
        }

    }
}