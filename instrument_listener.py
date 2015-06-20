import csv
class instrument_listener:
    def __init__(self, file_name, ext):
        self.file_name = file_name
        self.ext = ext
    def extract_events(self):
        l = []
        headers = None
        with open(self.file_name+"."+self.ext, 'rb') as csvfile:
            reader = csv.reader(csvfile)
            for row in reader:
                if headers == None:
                    headers = row
                else:
                    l.append( [row[0], row[2], headers[0]] )
                    l.append( [row[1], row[2], headers[1]] )
        l = sorted(l)
        with open(self.file_name+"_events."+self.ext, 'w') as csvfile:
            for row in l:
                csvfile.write(",".join(row)+'\n')
    def sort_by_start_time(self):
        l = []
        with open(self.file_name+"."+self.ext, 'rb') as csvfile:
            reader = csv.reader(csvfile)
            for row in reader:
                l.append( row )
        headers = l.pop(0)
        l = sorted(l)
        l = [headers]+l
        with open(self.file_name+"."+self.ext, 'w') as csvfile:
            for row in l:
                csvfile.write(",".join(row)+'\n')

instrument_listener("rainfall" ,"csv").sort_by_start_time()
instrument_listener("phoenix","csv").sort_by_start_time()