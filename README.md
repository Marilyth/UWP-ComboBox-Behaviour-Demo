# UWP-ComboBox-Bug-Demo
Showcase of a binding bug for UWP ComboBox indices.

![Bug](https://user-images.githubusercontent.com/19623152/203261657-c63a7de7-8952-49b1-bd76-2f3361f763c7.gif)

The index of a ComboBox is set to -1 if the ViewModel containing its Items is replaced. It is set back to 0 if the index was -1 and the ViewModel is replaced.
