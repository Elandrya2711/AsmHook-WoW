using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core = Tanaris.WoWObjects;

namespace UserApi.WoWObjects
{
    public class GameObject : BaseObject
    {
        #region Fields

        private Core.GameObject _gObject;

        #endregion

        #region Constructors

        public GameObject(uint baseAddress)
            : base(baseAddress)
        {
            _gObject = new Core.GameObject(baseAddress);
        }

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return _gObject.Name;
            }
        }

        public virtual Vector3 Location
        {
            get
            {
                return _gObject.Location;
            }
        }

        public float Orientation
        {
            get
            {
                return _gObject.Orientation;
            }
        }

        public virtual bool IsLootable
        {
            get
            {
                return _gObject.IsLootable;
            }
        }

        #endregion

        #region Methods
      
        public void Target()
        {
            _gObject.Target();
        }
      
        public virtual void Interact()
        {
            _gObject.Interact();
        }

        public virtual void Face()
        {
            _gObject.Face();
        }

        #endregion
    }
}
