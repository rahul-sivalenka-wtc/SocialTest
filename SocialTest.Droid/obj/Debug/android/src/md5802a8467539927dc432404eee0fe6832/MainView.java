package md5802a8467539927dc432404eee0fe6832;


public class MainView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SocialTest.Droid.Activities.MainView, SocialTest.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainView.class, __md_methods);
	}


	public MainView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainView.class)
			mono.android.TypeManager.Activate ("SocialTest.Droid.Activities.MainView, SocialTest.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
