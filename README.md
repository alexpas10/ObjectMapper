# Task

Create Mapper, which will map all public properties of object into another object. 
Properties must have same name and compatible type (for example int type can cast to 
string type etc.). Also all inner types must map with collection mapping support. You can 
implement additional settings up to you. 
 
Interface for Mapper (in addition you can add your own useful methods) 
 
<code> 
TDestination Map<TDestination>(object sourceObject);

object Map(object o, Type sourceType);
</code>

## Remarks
Method 
<code>
object Map(object o, Type sourceType);
</code>

is changed to:

<code>
object Map(object source, Type destinationType);
</code>
