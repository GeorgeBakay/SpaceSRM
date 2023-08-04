package crc64f3e1dbc24ca98a7d;


public class SimplePopupWindow
	extends android.widget.PopupWindow
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SimpleToolkit.Core.Handlers.SimplePopupWindow, SimpleToolkit.Core", SimplePopupWindow.class, __md_methods);
	}


	public SimplePopupWindow (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SimplePopupWindow.class) {
			mono.android.TypeManager.Activate ("SimpleToolkit.Core.Handlers.SimplePopupWindow, SimpleToolkit.Core", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public SimplePopupWindow (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SimplePopupWindow.class) {
			mono.android.TypeManager.Activate ("SimpleToolkit.Core.Handlers.SimplePopupWindow, SimpleToolkit.Core", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public SimplePopupWindow (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SimplePopupWindow.class) {
			mono.android.TypeManager.Activate ("SimpleToolkit.Core.Handlers.SimplePopupWindow, SimpleToolkit.Core", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
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
