using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace GameServer
{
    class Sphere
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 positionS;

        public Sphere(int _id, string _username, Vector3 _spawnPosition, Quaternion _rotation)
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
           
        }
 
        public void SetInputSphere(Quaternion _rotation, Vector3 _positionS)
        {
            rotation = _rotation;
            positionS = _positionS;
        }
    }
}
