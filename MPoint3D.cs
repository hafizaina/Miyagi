using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStorm.Miyagi.Framework
{
    public class MPoint3D
    {
        public float X;
        public float Y;
        public float Z;

        // Initializes a new MPoint3D with each component set to 0f
        public MPoint3D()
        {
            X = 0f;
            Y = 0f;
            Z = 0f;
        }

        public MPoint3D(float xPos, float yPos, float zPos)
        {
            SetPosition(xPos, yPos, zPos);
        }

        // Sets the position for this object
        public void SetPosition(float xPos, float yPos, float zPos)
        {
            this.X = xPos;
            this.Y = yPos;
            this.Z = zPos;
        }

        // Returns the position for this object
        public MPoint3D GetPosition()
        {
            return new MPoint3D(this.X, this.Y, this.Z);
        }

        public override string ToString()
        {
            return "This object is positioned at: " + "X = " + this.X +
                "Y = " + this.Y + "Z = " + this.Z;
        }

        /// <summary>
        /// This compares the X, Y, and Z components of two MPoint3D objects for equality.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(MPoint3D obj)
        {
            if ((this.X == obj.X) && (this.Y == obj.Y) && (this.Z == obj.Z))
            {
                return true;
            }
            return false;
        }
    }
}