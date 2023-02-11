using System;
using HelperMashin;

public class Helper : HelperStateMashin, IHelper
{
    private void Start()
    {
        Enter<MoveStateHelper>();
    }
}