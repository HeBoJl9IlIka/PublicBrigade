namespace Nevalyashka.Brigade.Model
{
    public static class Config
    {
        public enum TypesAction
        {
            Started,
            Performed,
            Canceled
        }

        public enum Actions
        {
            Move,
            DragDrop,
            Use,
            Throw,
            Rotation
        }

        public enum TypePlayerModel
        {
            one,
            two,
            three
        }

        public enum PlayerNumber
        {
            One,
            Two,
            Three,
            Four
        }

        public enum TypeConstructionMaterial
        {
            Null,
            Garbage,
            Glue,
            Wallpaper,
            Cement,
            TileAdhesive
        }

        public enum DraggerTaskType
        {
            Null,
            Table,
            Chair,
            Sofa,
            Tv
        }

        // Liftable
        public const float ThrowingPower = 5;
        public const float DurationDragEasyObject = 0.5f;
        public const int LiftableNumberTargetLayerMask = 9;

        // Character
        public const float MovingSpeedOffset = 0.1f;
        public const float CharacterDurationRotation = 0.5f;
        public const int CharacterNumberTargetLayerMask = 10;
        public const float CharacterMoveSpeed = 2;
        public const float CharacterSpeedChangeRate = 10;
        public const float CharacterSpeed = 0.5f;
        public const string AnimatorSpeed = "Speed";
        public const string AnimatorIsDraggingHeavy = "IsDraggingHeavy";
        public const string AnimatorAngle = "Angle";
        public const int AnimatorLayerEasy = 1;
        public const int AnimatorLayerHeavy = 2;
        public const int MaxAmountInventory = 100;
        public const float DurationMaterialBar = 0.3f;

        // Bucket
        public const int MaxAmountBucket = 200;
        public const int AmountDroppedMaterial = 20;

        // Tasks
        public const int TaskAmountConstructionMaterial = 20;
        public const int TaskAmountWaterToLawn = 20;
        public const int TaskAmountDestroy = 100;
        public const int TaskAmountConstruction = 100;
        public const int LayerNumberCurrentTask = 11;
        public const int LayerNumberCompletedTask = 12;
        public const int LayerNumberQueueTask = 13;

        // Tools
        public const int MaxAmountWateringCan = 100;
        public const int HammerGivingAmount = 20;

        // Camera
        public const float DurationRotateCamera = 0.5f;

        // Door
        //public const float DoorAnchorX = -0.5f;
        //public const float DoorAnchorY = 0;
        //public const float DoorAnchorZ = 0;
        //public const float DoorAxisX = 0;
        //public const float DoorAxisY = 1;
        //public const float DoorAxisZ = 0;
        //public const float DoorSpringForce = 5;
        //public const float DoorSpringDamper = 2;
        //public const float DoorLimitMin = -110;
        //public const float DoorLimitMax = 110;
    }
}
