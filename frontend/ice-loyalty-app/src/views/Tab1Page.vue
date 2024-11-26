<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title></ion-title>
        <ion-back-button></ion-back-button>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title size="large">Families</ion-title>
        </ion-toolbar>
      </ion-header>
      <div class="content-container">
        <section class="personalia centered">
          <ion-title>Hei {{ user.firstName }}!</ion-title>
          <h6>6 dager igjen av perioden</h6>

          <div class="personalia__saldo">
            <ion-card class="personalia__family-benefits">
              <ion-card-header>
                <div class="title-saldo">
                  <ion-card-title>Saldo</ion-card-title>
                  <ion-card color="warning" class="amount-cash"
                    ><span class="bold-subtitle">2 500</span> iceCash
                  </ion-card>
                </div>
              </ion-card-header>
              <ion-card-content class="family-bonuses__"
                >Du får iceCash pr. abo hvert hele år, som du f.eks. kan bruke
                på en ny mobil. Du kan også få iceCash ved andre aktiviteter,
                for eksempel ved å ha et bærekraftig forbruk 🌱
              </ion-card-content>
              <p class="underline-yellow">Les mer om iceCash</p>
            </ion-card>
          </div>
        </section>

        <section class="activated-services">
          <ion-title>Aktiverte Familietjenester</ion-title>

          <div class="activated-services__item">
            <ion-card class="services">
              <ion-card-content class="familie-fordeler">
                <ion-card-title class="bold-subtitle underline-yellow"
                  >iCloud</ion-card-title
                >
                <span>Aktivert</span>
              </ion-card-content>
            </ion-card>

            <ion-card class="services">
              <ion-card-content class="familie-fordeler">
                <ion-card-title class="bold-subtitle underline-yellow"
                  >iCloud</ion-card-title
                >
                <span>Aktivert</span>
              </ion-card-content>
            </ion-card>

            <ion-card class="services">
              <ion-card-content class="familie-fordeler">
                <ion-card-title class="bold-subtitle underline-yellow"
                  >iCloud</ion-card-title
                >
                <span>Aktivert</span>
              </ion-card-content>
            </ion-card>
          </div>
        </section>

        <section class="your-family centered">
          <ion-title>Din familie</ion-title>

          <ion-card>
            <ion-card-content>
              <ion-card-header>
                <ion-card-title class="bold-subtitle underline-yellow"
                  >{{ user.firstName }} {{ user.lastName }}</ion-card-title
                >
              </ion-card-header>
              <span>{{ user.subscription }} - {{ user.phoneNumber }} </span>
            </ion-card-content>
          </ion-card>
        </section>
      </div>

      <!--      <ion-card v-if="families && families.length">-->
      <!--        <ion-card-header>-->
      <!--          <ion-card-title>Family Data</ion-card-title>-->
      <!--        </ion-card-header>-->
      <!--        <ion-card-content>-->
      <!--          <ul>-->
      <!--            <li v-for="(family, index) in families" :key="index">-->
      <!--              <p><strong>Date:</strong> {{ family.date }}</p>-->
      <!--              <p><strong>Coin:</strong> {{ family.coin }}</p>-->
      <!--              <p><strong>Summary:</strong> {{ family.summary }}</p>-->
      <!--              <p><strong>Temperature (F):</strong> {{ family.temperatureF }}</p>-->
      <!--            </li>-->
      <!--          </ul>-->
      <!--        </ion-card-content>-->
      <!--      </ion-card>-->

      <!--      <ion-card v-else>-->
      <!--        <ion-card-header>-->
      <!--          <ion-card-title>Loading...</ion-card-title>-->
      <!--        </ion-card-header>-->
      <!--        <ion-card-content>-->
      <!--          Please wait while we fetch the family data.-->
      <!--        </ion-card-content>-->
      <!--      </ion-card>-->
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import {
  IonPage,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonCard,
  IonCardHeader,
  IonCardTitle,
  IonCardContent,
  IonBackButton,
} from "@ionic/vue";
import { ref, onMounted } from "vue";

interface Family {
  date: string;
  coin: number;
  summary: string;
  temperatureF: number;
}

interface User {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  subscription?: string;
}

const families = ref<Family[]>([]);
const user = ref<User>({
  firstName: "Kari",
  lastName: "Nordmann",
  phoneNumber: "412 33 342",
  subscription: "iceUnlimited",
});

const fetchFamilies = async () => {
  try {
    const response = await fetch("http://localhost:5104/families");
    if (!response.ok) {
      throw new Error(`Error fetching families: ${response.statusText}`);
    }
    families.value = await response.json();
  } catch (error) {
    console.error("Error fetching families:", error);
  }
};

onMounted(fetchFamilies);
</script>
<style lang="scss">
.centered {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.content-container {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  padding: 1.25rem;
  margin: 0 auto;
}

.flex-row {
  display: flex;
  flex-direction: row;
}

ion-card {
  border-radius: 0.5rem;
}

.personalia {
  display: flex;
  flex-direction: column;
  margin-top: 2rem;

  &__family-benefits {
    display: flex;
    flex-direction: column;
    width: 100%;
  }
}

.bold-subtitle {
  font-weight: bold;
}

.saldo {
  display: flex;
  flex-direction: row;
  gap: 0.5rem;
  width: 50%;
}

.familiy-benefits {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  width: 50%;
}

ion-content {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.underline-yellow {
  border-bottom: 1px solid var(--Yellow-yellow-40, #ffcd00);
}

.activated-services {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.activated-services__item {
  display: flex;
  flex-direction: row;
  gap: 1rem;

  > * {
    // Target all direct children
    flex: 1; // Ensures all cards take equal space
    display: flex;
    flex-direction: column; // Maintain column layout for content
    justify-content: center;
    align-items: center;
  }
}

.amount-cash {
  padding: 0.3rem;
  border-radius: 0.8rem;
}

.title-saldo {
  display: flex;
  flex-direction: row;
  //flex-wrap: initial;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1px solid var(--Grey-grey-70, #eaecf0);
}

span {
  white-space: nowrap;
}
</style>
