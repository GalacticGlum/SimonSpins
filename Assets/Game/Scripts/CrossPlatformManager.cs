public static class CrossPlatformManager 
{
    public static bool Mobile
    {
        get
        {
#if (UNITY_ANDROID || UNITY_IOS)
            return true;
#else
            return false;
#endif
        }
    }

    public static bool Standalone
    {
        get
        {
#if (UNITY_STANDALONE)
            return true;
#else
            return false;
#endif
        }
    }
}
