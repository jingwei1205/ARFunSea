    var frequMin : float = 1.0;
    var frequMax : float = 2.2;
    var height : float = 0.014;
    private var randomInterval : float;
     
    function Start () {
        randomInterval = Random.Range(frequMin, frequMax);
    }
     
    function Update () {
        this.transform.position.y += (Mathf.Cos(Time.time * randomInterval) * height);
        this.transform.eulerAngles.x += (Mathf.Cos(Time.time * randomInterval) * 2);
    }