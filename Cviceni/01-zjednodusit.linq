<Query Kind="Statements">
  <Connection>
    <ID>c6276dcd-3781-4075-afd8-b5a70f6d1f09</ID>
    <Persist>true</Persist>
    <Server>NUTRISERVER\SQLEXPRESS</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>yogenaonlineportal</Database>
    <UserName>yogadio</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAADDRHNzJQZUuw+TrSpZ94LwAAAAACAAAAAAAQZgAAAAEAACAAAACGuM6gydy8f/k5ND+WNQOUOtekenG4uy4+PD4ZFQTKewAAAAAOgAAAAAIAACAAAADsD8KFO9TB3aE7EK1XbW6ShPpbcKu5naMs7Le420cStiAAAABPDe4LhfTZM1wyVlf9YArsEs6HykGm6f/1ek245ccNvkAAAAAs9+aCtp4ySqB566s7IPJlkaRIM1DS4cyxEPi94wAOJaO25KZu8nzL1ymPPJUpWC64mVSlZbwz7nkufjtcP7dC</Password>
  </Connection>
</Query>

/// 1. přepište přiřazenído IsOverThreshold na kratší a čitelnější formu

double data = 6;
bool IsOverTreshold;
if (data > 5.5)
{
	IsOverTreshold = true;
}
else
{
	IsOverTreshold = false;	
}


/// 2. přepište přižazení registrationFee na kratší a čitelnější formu

bool isSpeaker = false;
int registrationFee;
if(isSpeaker)
{
	registrationFee = 0;
}
else
{
	registrationFee = 50;
}

