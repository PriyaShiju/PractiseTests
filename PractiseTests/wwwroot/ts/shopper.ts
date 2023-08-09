namespace PractiseTests.wwwroot.ts
{ 
    class Shopper
    {
    
        constructor(private firstname: string, private lastname: string) {
       
        }

        public showName() {
            alert(`${this.firstname} {this.lastname}`);

        }
     }
    let shopper = new Shopper("Priya", "Padmanabhan");
}