EXTRA_DIRS =

DIRS=generator api glib pango atk gdk art gtk glade gnome sample
ROOT=/cygdrive/$(subst \,/,$(subst :\,/,$(SYSTEMROOT)))
CSC=$(ROOT)/microsoft.net/framework/v1.0.3705/csc.exe
MCS=mcs

all: linux

windows:
	for i in $(DIRS); do				\
		(cd $$i; CSC=$(CSC) make windows) || exit 1;\
	done;

unix:
	@echo "'make unix' is broken for now."

linux: native binding

binding:
	for i in $(DIRS); do				\
		(cd $$i; MCS="$(MCS)" make) || exit 1;\
	done;

native:
	(cd glue; make) || exit 1;

clean:
	for i in glue $(DIRS); do				\
		(cd $$i; make clean) || exit 1;	\
	done;

distclean: clean
	(cd glue; make distclean) || exit 1;
	for i in $(DIRS); do				\
		rm -f $$i/Makefile;			\
	done
	rm -f config.cache config.h config.log config.status libtool

install: install-native install-binding

install-binding:
	for i in $(DIRS); do				\
		(cd $$i; make install) || exit 1;	\
	done;

install-native:
	(cd glue; make install) || exit 1;	\

