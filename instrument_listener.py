import csv
class instrument_listener:
    def __init__(self, file_name):
        l = []
        with open(file_name, 'rb') as csvfile:
            reader = csv.reader(csvfile)
            for row in reader:
                l.append( row )
        headers = l.pop(0)
        l = sorted(l)
        l = [headers]+l
        with open(file_name, 'w') as csvfile:
            for row in l:
                csvfile.write(",".join(row)+'\n')
        
instrument_listener("rainfall.csv")
instrument_listener("phoenix.csv")