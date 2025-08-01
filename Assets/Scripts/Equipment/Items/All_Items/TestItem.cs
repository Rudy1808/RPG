using UnityEngine;

public class TestItem : Item
{
    public TestItem()
        {
        ID = 0;
        name = "TestItem";
        description = "";
        Icon = Resources.Load<Texture2D>("itemIcons/TestItemIcon");
        }
}
