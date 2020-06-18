# Tim21

Detalji implementacije

Implementacija sadrzi 4 projekta: Writer,DumpingBuffer,Historical i Biblioteku.
U Biblioteci se cuvaju zajednicke klase.Writer random generise Value i Code,zatim salje preko svoje klase podatke ka Baferu.
Bafer preuzima vrijednosti,odredjuje dataset i pakuje ih u svoju strukturu CD.CD dodaje u listu. Bafer izvrsava azuriranje podataka ukoliko se ukaze potreba.
Po izpunjenju uslova za slanje Bafer pakuje CDove u DeltaCD, ukoliko nema CDova odlaze slanje.
Nakon pakovanja u DeltaCD bafer salje podatke Historicalu koji podatke iz DeltaCD preuzima i pakuje u svoju LD strukturu.DeltaCD i lista CDova se oslobadjaju za prijem novih podataka.
Nakon pakovanja u LD Historical kreira kontekst za bazu i vrsi unaprijed operacije odredjene sadrzajem podataka koje je dobio.Lista Descriptiona se nakon toga oslobadja za nove podatke.
Writer ima mogucnost Manuelnog upisa u istoriju i Dobijanja vrijednosti iz baze za unijeti kod.Za to je obezbijedjen meni.
U loger se biljeze operacije sa podacima.

Dijagram nisam stigao uraditi.U zadatku je koristeno dosta klasa sa praznim konstruktorima sto je onemogucilo kvalitetno testiranje.Te klase su koristene da bi podijelio rad na vise klasa i izbjegao staticka polja - nije optimalno rjesenje.

Tim21
