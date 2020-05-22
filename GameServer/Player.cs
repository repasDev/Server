using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace GameServer
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 spherePosition;
        public Quaternion sphereRotation;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 positionM;

        public Player(int _id, string _username, Vector3 _spawnPosition, Quaternion _rotation)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = _rotation;
            
        }



        public void Update()
        {
            Move();
        }
        private void Move()
        {
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
            ServerSend.SpherePosition2(this);
            ServerSend.SphereRotation2(this);
        }
        public void SetInput(Quaternion _rotation, Vector3 _positionM)
        {
            rotation = _rotation;
            positionM = _positionM;
        }

        public void GetSphere(Vector3 _spherePosition, Quaternion _sphereRotation)
        {
            spherePosition = _spherePosition;
            sphereRotation = _sphereRotation;
        }
     
    }
}
