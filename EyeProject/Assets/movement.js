#pragma strict

var mode : GUIText;
var speed_x:float=0.1;
var speed_y:float=0.1;
private var i:int=0;
function Start () {
				
}

function Update () {
		
		if(Input.GetButtonUp("Readmode")){
			mode.text="Read Mode";
			this.transform.position=Vector3(-6,4,0);	
			speed_x=0.1;
		}
		if(mode.text=="Read Mode"){

			this.transform.Translate(speed_x,0,0);
			if(this.transform.position.x>=6)
			{
				this.transform.position=Vector3(-6,this.transform.position.y-1,0);
			}
			if(this.transform.position.y<=-4)
			{
				this.transform.position=Vector3(-6,4,0);
			}
		}
		
		
		if(Input.GetButtonUp("collisionmode")){
			mode.text="Collision Mode";
			this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	
			speed_x=Random.Range(0.05,0.15);		
			speed_y=Random.Range(0.05,0.15);		
		}
		if(mode.text=="Collision Mode"){
			this.transform.Translate(speed_x,speed_y,0);

			if(this.transform.position.x>=6||this.transform.position.x<=-6)
			{
				speed_x=-speed_x;
			}
			if(this.transform.position.y<=-4||this.transform.position.y>=4)
			{
				speed_y=-speed_y;
			}
		}
		
		if(Input.GetButtonUp("noedgenmode")){
			mode.text="No Edge Mode";
			this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	
			speed_x=Random.Range(0.05,0.15);	
			if(Random.Range(-1,1)<0)
				speed_x=-speed_x;
			speed_y=Random.Range(0.05,0.15);	
			if(Random.Range(-1,1)<0)
				speed_y=-speed_y;	
		}
		if(mode.text=="No Edge Mode"){
			this.transform.Translate(speed_x,speed_y,0);

			if(this.transform.position.x>6)
			{
				this.transform.position.x=-6;
			}
			if(this.transform.position.y<-4)
			{
				this.transform.position.y=4;
			}
			if(this.transform.position.x<-6)
			{
				this.transform.position.x=6;
			}
			if(this.transform.position.y>4)
			{
				this.transform.position.y=-4;
			}
		}
		
		if(Input.GetButtonUp("Rancollisionmode")){
			mode.text="Random Collision Mode";
			this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	
			speed_x=Random.Range(0.05,0.15);		
			speed_y=Random.Range(0.05,0.15);

		}
		if(mode.text=="Random Collision Mode"){
			this.transform.Translate(speed_x,speed_y,0);
			i++;

			if(i>200)
			{				
				this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	
				speed_x=Random.Range(0.05,0.15);		
				speed_y=Random.Range(0.05,0.15);
				i=0;			
			}

			if(this.transform.position.x>6)
			{
				this.transform.position.x=6;
				speed_x=-speed_x;
			}
			if(this.transform.position.y<-4)
			{
				this.transform.position.y=-4;
				speed_y=-speed_y;
			}
			if(this.transform.position.x<-6)
			{
				this.transform.position.x=-6;
				speed_x=-speed_x;
			}
			if(this.transform.position.y>4)
			{
				this.transform.position.y=4;
				speed_y=-speed_y;
			}
		}
		
		
		if(Input.GetButtonUp("Flashmode")){
			mode.text="Flash Mode";
			this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	


		}
		if(mode.text=="Flash Mode"){

			i++;

			if(i>50)
			{				
				this.transform.position=Vector3(Random.Range(-6,6),Random.Range(-4,4),0);	

				i=0;			
			}

		}
		
}